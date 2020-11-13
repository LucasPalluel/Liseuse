using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;

namespace PPE
{
    partial class FRM_NumeriBook
    {
        private USRCTRL_Notification notif;
        private Liseuse liseuse = null;
        private BackgroundWorker bgw_comparaison;
        private FRM_DialogueTransfert fRM_DialogueTransfert;
        /// <summary>
        /// Affiche dans le coins une notification
        /// </summary>
        private void NotifPeripherique(string message)
        {
            //MessageBox.Show("Affichage");
            notif = new USRCTRL_Notification(message);
            notif.Location = new System.Drawing.Point(this.Width - 300, this.Height - 100);
            this.notif.BackColor = System.Drawing.Color.Transparent;
            this.notif.Name = "notif";
            this.notif.Size = new System.Drawing.Size(300, 200);
            this.notif.TabIndex = 49;
            notif.Click += new EventHandler(NotifOnClick);
            Controls.Add(notif);
            notif.TIMER.Tick += new EventHandler(disposeNotification);
            notif.BringToFront();

        }

        private void NotifOnClick(object sender, EventArgs e)
        {
            Controls.Remove(notif);
        }

        private void disposeNotification(object sender, EventArgs e)
        {
            Controls.Remove(notif);
        }

        protected override void DefWndProc(ref Message m)
        {

            if (m.Msg == LiaisonAppLiseuse.WM_DEVICECHANGE) //Message windows d'un changement dans un périphérique
            {
                if (m.WParam.ToInt32() == LiaisonAppLiseuse.DBT_DEVICEARRIVAL) // Un périphérique vient d'être branché
                {
                    //NotifPeripherique("un périphérique a été branché");

                    LiaisonAppLiseuse.DEV_BROADCAST_HDR hdr = (LiaisonAppLiseuse.DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(LiaisonAppLiseuse.DEV_BROADCAST_HDR));

                    if (hdr.dbch_devicetype == LiaisonAppLiseuse.DBT_DEVTYP_VOLUME)
                    {
                        char letter = LiaisonAppLiseuse.DetermineLettre(m);

                        //NotifPeripherique("Le périphérique à été branché en " + letters[0].ToString());

                        if (LiaisonAppLiseuse.IsAReadableKobo(letter))
                        {

                            if (new FRM_DialogueAutorise((char)(letter - 32)).ShowDialog() == DialogResult.OK)
                            {
                                liseuse = new Liseuse(letter);
                                AfficherBoutonPeripherique();
                                bgw_comparaison.RunWorkerAsync();
                            }
                        }

                    }
                }

                //Si un périphérique est retirer
                if (m.WParam.ToInt32() == LiaisonAppLiseuse.DBT_DEVICEREMOVECOMPLETE)
                {
                    LiaisonAppLiseuse.DEV_BROADCAST_HDR hdr = (LiaisonAppLiseuse.DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(LiaisonAppLiseuse.DEV_BROADCAST_HDR));

                    if (hdr.dbch_devicetype == LiaisonAppLiseuse.DBT_DEVTYP_VOLUME)
                    {

                        char letter = LiaisonAppLiseuse.DetermineLettre(m);

                        if (liseuse != null)
                        {
                            if (liseuse.Lecteur == letter)
                            {
                                EjectLiseuse();
                            }
                        }

                    }
                }
            }
            base.DefWndProc(ref m);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.L)
            {
                BT_Peripherique.PerformClick(); 
            }
            if (e.Control && e.KeyCode == Keys.M)
            {
                AfficherBoutonPeripherique();
                //B_EnvoyerVersMemoirePrincipale.PerformClick();
            }

            if(e.Alt && e.KeyCode == Keys.L)
            {
                EjectUSB.EjectDrive('g');
            }
            //if(e.Control && e.KeyCode == Keys.M)
            //{
            //    EjectUSB.EjectDrive('')
            //}

            base.OnKeyDown(e);
        }
        private void AfficherBoutonPeripherique(bool vf = true)
        {
            Control[] tmp = new Control[]
            {
                BT_Devices,
                BT_EnvoiPeriph,
                B_FlecheEnvoiePeriph,
                Lb_EnvoiPeriph
            };
            foreach (Control ctl in tmp)
            {
                ctl.Visible = vf;
            }
        }

        private void comparaisonDoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                if (liseuse != null)
                {
                    fRM_DialogueTransfert = new FRM_DialogueTransfert(liseuse.CompareLiseuse(biblio));
                }
                else
                {
                    throw new Exception("Liseuse n'est pas instancié pour la comparaison");
                }
            }
            catch (Exception exc)
            {
                ExceptionHandler.ExeptionCatch(exc);
            }
        }
        private void comparaisonComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            //a finir
            DialogResult result = fRM_DialogueTransfert.ShowDialog();
            List<Liseuse.Livre> livres = new List<Liseuse.Livre>();
            switch (result)
            {
                case DialogResult.OK:
                    foreach(object obj in fRM_DialogueTransfert.LB_Livres.SelectedItems)
                    {
                        livres.Add((Liseuse.Livre)obj);
                    }
                    break;
                case DialogResult.Yes:
                    foreach (object obj in fRM_DialogueTransfert.LB_Livres.Items)
                    {
                        livres.Add((Liseuse.Livre)obj);
                    }
                    break;
                case DialogResult.Abort: break;
                case DialogResult.Cancel: break;
                default: break;
            }
            if(livres.Count > 0)
            {
                FRM_LoadingLiseuse ll = new FRM_LoadingLiseuse(livres.Count);
                ll.Phrase = "Importation des livres dans la bibliothèque";
                ll.Show();
                foreach(Liseuse.Livre livre in livres)
                {
                    try
                    {
                        ClassAjout.AjoutEpub(livre.PATH, livre.FileName, biblio);
                    }
                    catch(Exception exc)
                    {
                        ExceptionHandler.ExeptionCatch(exc);
                    }
                    ll.pas();
                }
                ll.Close();
                AfficheLesEnregistrementsEpub();
            }
        }

        /// <summary>
        /// Event du click sur le bouton périphérique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Peripherique_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dos = new FolderBrowserDialog();
            dos.Description = "Veuillez choissir le volume de la liseuse";


            if (dos.ShowDialog() == DialogResult.OK)
            {
                char letter = dos.SelectedPath[0];
                if (LiaisonAppLiseuse.IsAReadableKobo(letter))
                {

                    if (new FRM_DialogueAutorise(letter>90?(char)(letter - 32):letter).ShowDialog() == DialogResult.OK)
                    {
                        liseuse = new Liseuse(letter);

                        AfficherBoutonPeripherique();

                        bgw_comparaison.RunWorkerAsync();

                    }
                }
                else
                {
                    MessageBox.Show("Le volume selectionné n'est pas une Kobo");
                }
            }
        }

        /// <summary>
        /// Event de l'affichage des livres de la liseuse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_AfficherLivreContenuPeriph_Click(object sender, EventArgs e)
        {
            if (liseuse != null)
            {
                FRM_DialogueLivreLiseuse frm = new FRM_DialogueLivreLiseuse(liseuse.Biblioteque);
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// Envoie les livres selectionné vers la liseuse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_EnvoyerVersMemoirePrincipale_Click(object sender, EventArgs e)
        {
            if (liseuse != null) {
                if (!liseuse.IsBusy)
                {
                    if(LV_Livre.SelectedItems.Count > 0)
                        liseuse.ExportLivre(GetAllSelectedLivres());
                }
            }

        }

        /// <summary>
        /// Ejection de la liseuse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_EjecterPeriph_Click(object sender, EventArgs e)
        {
            if(liseuse != null)
            {
                if(!liseuse.IsBusy)
                {
                    if (EjectUSB.EjectDrive(liseuse.Lecteur))
                    {
                        EjectLiseuse();
                    }
                }
            }
        }


        private void B_MAJMetadonnees_Click(object sender, EventArgs e)
        {
            if(liseuse != null)
            {
                if(!liseuse.IsBusy)
                {
                    MessageBox.Show("Liseuse en préparation");
                    fRM_DialogueTransfert = new FRM_DialogueTransfert(liseuse.CompareLiseuse(biblio));
                    comparaisonComplete(this, new RunWorkerCompletedEventArgs(this,new Exception(), false));
                }
            }
        }

        private void EjectLiseuse()
        {
            liseuse = null;
            AfficherBoutonPeripherique(false);
            MessageBox.Show("La liseuse à été retiré");
        }




    }
}
