using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace PPE
{
    public class LiaisonAppLiseuse
    {
        public const int WM_DEVICECHANGE = 0x0219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        public const int DBT_DEVTYP_VOLUME = 0x2;
        /*
        protected override void WndProc(ref Message m)
        {
            // le message est de type DEVICECHANGE, ce qui nous interesse
            if (m.Msg == WM_DEVICECHANGE)
            {
                // le "sous-message" dit que le device vient d'etre pluggé
                if (m.WParam.ToInt32() == DBT_DEVICEARRIVAL)
                {
                    // device plugged

                    // on créé une structure depuis un pointeur a l'aide du Marshalling
                    // cette structure est generique mais on peut "l'interroger" comme une structure DEV_BROADCAST_HDR
                    DEV_BROADCAST_HDR hdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));

                    // ok, le device pluggé est un volume (aussi appelé 'périphérique de stockage de masse')...
                    if (hdr.dbch_devicetype == DBT_DEVTYP_VOLUME)
                    {
                        // ... et donc on recréé une structure, a partir du même pointeur de structure "générique",
                        // une structure un poil plus spécifique
                        DEV_BROADCAST_VOLUME vol = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_VOLUME));
                        // le champs dbcv_unitmask contient la ou les lettres de lecteur du ou des devices qui viennent d'etre pluggé
                        // MSDN nous dit que si le bit 0 est à 1 alors le lecteur est a:, si le bit 1 est à 1 alors le lecteur est b:
                        // et ainsi de suite
                        uint mask = vol.dbcv_unitmask;
                        // recupèration des lettres de lecteurs
                        char[] letters = MaskDepioteur(mask);

                        // mise à jour de l'IHM pour notifier nos petits yeux tout content :)
                        this.Text = string.Format("USB key plugged on drive {0}:", letters[0].ToString().ToUpper());
                    }
                }
                // le device vient d'etre retirer bourrinement ou proprement
                // (ce message intervient même quand on défait la clef softwarement mais qu'elle reste physiquement branché)
                else if (m.WParam.ToInt32() == DBT_DEVICEREMOVECOMPLETE)
                {
                    // device removed

                    // mise à jour de l'IHM
                    this.Text = "USB key unplugged";
                }
            }

            // laissons notre fenêtre faire tout de même son boulot
            base.WndProc(ref m);
        }
        */
        public static bool IsAReadableKobo(char lecteur)
        {
            return File.Exists(lecteur.ToString() + @":\.kobo\KoboReader.sqlite");
        }
        public static char[] MaskDepioteur(uint mask)
        {
            int cnt = 0;
            uint temp_mask = mask;

            // on compte le nombre de bits à 1
            for (int i = 0; i < 32; i++)
            {
                if ((temp_mask & 1) == 1)
                    cnt++;
                temp_mask >>= 1;
                if (temp_mask == 0)
                    break;
            }

            // on instancie le bon nombre d'elements
            char[] result = new char[cnt];
            cnt = 0;
            // on refait mais ce coup ci on attribut
            for (int i = 0; i < 32; i++)
            {
                if ((mask & 1) == 1)
                    result[cnt++] = (char)('a' + i);
                mask >>= 1;
                if (mask == 0)
                    break;
            }

            return (result);
        }

        // structure générique
        public struct DEV_BROADCAST_HDR
        {
            public uint dbch_size;
            public uint dbch_devicetype;
            public uint dbch_reserved;
        }

        // structure spécifique
        // notez qu'elle a strictement le même tronche que la générique mais
        // avec des trucs en plus
        public struct DEV_BROADCAST_VOLUME
        {
            public uint dbcv_size;
            public uint dbcv_devicetype;
            public uint dbcv_reserved;
            public uint dbcv_unitmask;
            public ushort dbcv_flags;
        }

        public static char DetermineLettre(Message m)
        {

            LiaisonAppLiseuse.DEV_BROADCAST_VOLUME vol = (LiaisonAppLiseuse.DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(LiaisonAppLiseuse.DEV_BROADCAST_VOLUME));
            char[] letters = LiaisonAppLiseuse.MaskDepioteur(vol.dbcv_unitmask);
            return letters[0];
        }
    }
}
