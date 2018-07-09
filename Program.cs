using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;


namespace Keyboard_1
{

    public class BackEnd //module
    {
        public const int WIDTH = 1237;
        public const int HEIGHT = 429;
        public const int ARROWSWIDTH = 284;
        public const int ARROWSHEIGHT = 202;
        public static int screenWidth = Screen.PrimaryScreen.WorkingArea.Right;
        public static int screenHeight = Screen.PrimaryScreen.WorkingArea.Bottom;

        public static IDictionary<int, Bitmap> imageDict = new Dictionary<int, Bitmap>();
        public static String currentHoverColor = "#000000";
        public static String currentHoverColorArrows = "#000000";

        public static Bitmap mask = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.New_Keyboard_Small_Gradient_NoBackground);
        public static Bitmap keyDownCanvas = new System.Drawing.Bitmap(WIDTH, HEIGHT);
        public static Bitmap keyHoverCanvas = new System.Drawing.Bitmap(WIDTH, HEIGHT);
        public static Bitmap blankCanvas = new System.Drawing.Bitmap(WIDTH, HEIGHT); // always empty
        public static Bitmap allKeysDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.New_Keyboard_Small_KeyDown_NoBackground);
        public static Bitmap allKeysUp = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.New_Keyboard_Small_KeyUp_NoBackground);
        public static Bitmap capitalKeysDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.New_Keyboard_Small_KeyDown_Maxima);
        public static Bitmap capitalKeysUp = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.New_Keyboard_Small_KeyUp_Maxima);

        public static Bitmap arrows_Mask = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.Arrows_Small_Mask_ff00ff);
        public static Bitmap arrows_KeysUp = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.Arrows_Small_KeysUp);
        public static Bitmap arrowsBlankCanvas = new System.Drawing.Bitmap(ARROWSWIDTH, ARROWSHEIGHT); // always empty
        public static Bitmap arrowsKeyDownCanvas = new System.Drawing.Bitmap(ARROWSWIDTH, ARROWSHEIGHT); // always empty
        public static Bitmap arrowsHoverCanvas = new System.Drawing.Bitmap(ARROWSWIDTH, ARROWSHEIGHT); // always empty

        public static Bitmap pholimDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Pholim);                 // (01)
        public static Bitmap jyamDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Jyam);                   // (02)
        public static Bitmap jzhadDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Jzhad);                  // (03)
        public static Bitmap nexusDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Nexus);                  // (04)
        public static Bitmap kehtaDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Kehta);                  // (05)
        public static Bitmap aderDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Ader);                   // (06)
        public static Bitmap alnaDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Alna);                   // (07)
        public static Bitmap thatusDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Thatus);                 // (08)
        public static Bitmap amienDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Amien);                  // (09)
        public static Bitmap athusDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Athus);                  // (10)
        public static Bitmap haxtDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Haxt);                   // (11)
        public static Bitmap venikDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Venik);                  // (12)
        public static Bitmap haruxDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Harux);                  // (13)
        public static Bitmap raDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Ra);                     // (14)
        public static Bitmap renDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Ren);                    // (15)
        public static Bitmap risDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Ris);                    // (16)
        public static Bitmap barimDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Barim);                  // (17)
        public static Bitmap bartaDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Barta);                  // (18)
        public static Bitmap setoDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Seto);                   // (19)
        public static Bitmap karthonDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Karthon);                  // (20)
        public static Bitmap dolusDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Dolus);                  // (21)
        public static Bitmap jensisDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Jensis);                 // (22)
        public static Bitmap gaminDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Gamin);                  // (23)
        public static Bitmap payterDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Payter);                 // (24)
        public static Bitmap tomaDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Toma);                   // (25)
        public static Bitmap trisDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Tris);                   // (26)
        public static Bitmap tyelDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Tyel);                   // (27)
        public static Bitmap vexDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Vex);                    // (28)
        public static Bitmap aziumDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Azium);                  // (29)
        public static Bitmap efelidDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Efelid);                 // (30)
        public static Bitmap esisDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Esis);                   // (31)
        public static Bitmap fearonDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Fearon);                 // (32)
        public static Bitmap lodusDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Lodus);                  // (33)
        public static Bitmap memonDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Memon);                  // (34)
        public static Bitmap nefronDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Nefron);                 // (35)
        public static Bitmap nonumDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Nonum);                  // (36)
        public static Bitmap solaDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Sola);                   // (37)
        public static Bitmap diamondDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Diamond);                // (38)
        public static Bitmap sudenDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Suden);                  // (39)
        public static Bitmap exoDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Exo);                    // (40)
        public static Bitmap ilunumDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Ilunum);                 // (41)
        public static Bitmap ixiumDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Ixium);                  // (42)
        public static Bitmap oberonDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Oberon);                 // (43)
        public static Bitmap odiumDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Odium);                  // (44)
        public static Bitmap commaDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Comma);                  // (45)
        public static Bitmap ocillumDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Ocillum);                // (46)
        public static Bitmap ojiumDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Ojium);                  // (47)
        public static Bitmap opsenDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Opsen);                  // (48)
        public static Bitmap ortheksDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Ortheks);                // (49)
        public static Bitmap parsusDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Parsus);                 // (50)
        public static Bitmap periodDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Period);                 // (51)
        public static Bitmap kanoraDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Kanora);                 // (52)
        public static Bitmap wironDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Wiron);                  // (53)
        public static Bitmap urnaDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Urna);                   // (54)
        public static Bitmap chrismDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Chrism);                 // (55)
        public static Bitmap antagonisticCliticDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Antagonisticclitic);     // (56)
        public static Bitmap usisDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Usis);                   // (57)
        public static Bitmap uvielDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Uviel);                  // (58)
        public static Bitmap uzionDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Uzion);                  // (59)
        public static Bitmap dexinDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Dexin);                  // (60)
        public static Bitmap cooperativeCliticDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Cooperativeclitic);      // (61)
        public static Bitmap yaltaDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Yalta);                  // (62)
        public static Bitmap backspaceDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Backspace);              // (63)
        public static Bitmap eshnaDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Eshna);                  // (64)
        public static Bitmap cliticDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Clitic);                 // (65)
        public static Bitmap circleDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Circle);                 // (66)
        public static Bitmap deleteDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Delete);                 // (67)
        public static Bitmap yamenDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Yamen);                  // (68)
        public static Bitmap dualCliticDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Dualclitic);             // (69)
        public static Bitmap squareDown = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.keyDown_Square);                 // (70)

        public static Bitmap arrows_KeyDown_Left = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.Arrows_Small_KeysDown_Left);   // (01)
        public static Bitmap arrows_KeyDown_Up = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.Arrows_Small_KeysDown_Up);       // (02)
        public static Bitmap arrows_KeyDown_Right = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.Arrows_Small_KeysDown_Right); // (03)
        public static Bitmap arrows_KeyDown_Down = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.Arrows_Small_KeysDown_Down);   // (04)


        public static Bitmap pholimHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.pholimHover);                 // (01)
        public static Bitmap jyamHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.jyamHover);                   // (02)
        public static Bitmap jzhadHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.jzhadHover);                  // (03)
        public static Bitmap nexusHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.nexusHover);                  // (04)
        public static Bitmap kehtaHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.kehtaHover);                  // (05)
        public static Bitmap aderHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.aderHover);                   // (06)
        public static Bitmap alnaHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.alnaHover);                   // (07)
        public static Bitmap thatusHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.thatusHover);                 // (08)
        public static Bitmap amienHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.amienHover);                  // (09)
        public static Bitmap athusHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.athusHover);                  // (10)
        public static Bitmap haxtHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.haxtHover);                   // (11)
        public static Bitmap venikHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.venikHover);                  // (12)
        public static Bitmap haruxHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.haruxHover);                  // (13)
        public static Bitmap raHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.raHover);                     // (14)
        public static Bitmap renHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.renHover);                    // (15)
        public static Bitmap risHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.risHover);                    // (16)
        public static Bitmap barimHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.barimHover);                  // (17)
        public static Bitmap bartaHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.bartaHover);                  // (18)
        public static Bitmap setoHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.setoHover);                   // (19)
        public static Bitmap karthonHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.karthHover);                  // (20)
        public static Bitmap dolusHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.dolusHover);                  // (21)
        public static Bitmap jensisHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.jensisHover);                 // (22)
        public static Bitmap gaminHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.gaminHover);                  // (23)
        public static Bitmap payterHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.payterHover);                 // (24)
        public static Bitmap tomaHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.tomaHover);                   // (25)
        public static Bitmap trisHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.trisHover);                   // (26)
        public static Bitmap tyelHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.tyelHover);                   // (27)
        public static Bitmap vexHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.vexHover);                    // (28)
        public static Bitmap aziumHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.aziumHover);                  // (29)
        public static Bitmap efelidHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.efelidHover);                 // (30)
        public static Bitmap esisHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.esisHover);                   // (31)
        public static Bitmap fearonHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.fearonHover);                 // (32)
        public static Bitmap lodusHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.lodusHover);                  // (33)
        public static Bitmap memonHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.memonHover);                  // (34)
        public static Bitmap nefronHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.nefronHover);                 // (35)
        public static Bitmap nonumHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.nonumHover);                  // (36)
        public static Bitmap solaHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.solaHover);                   // (37)
        public static Bitmap diamondHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.diamondHover);                // (38)
        public static Bitmap sudenHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.sudenHover);                  // (39)
        public static Bitmap exoHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.exoHover);                    // (40)
        public static Bitmap ilunumHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.ilunumHover);                 // (41)
        public static Bitmap ixiumHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.ixiumHover);                  // (42)
        public static Bitmap oberonHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.oberonHover);                 // (43)
        public static Bitmap odiumHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.odiumHover);                  // (44)
        public static Bitmap commaHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.commaHover);                  // (45)
        public static Bitmap ocillumHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.ocillumHover);                // (46)
        public static Bitmap ojiumHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.ojiumHover);                  // (47)
        public static Bitmap opsenHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.opsenHover);                  // (48)
        public static Bitmap ortheksHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.ortheksHover);                // (49)
        public static Bitmap parsusHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.parsusHover);                 // (50)
        public static Bitmap periodHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.periodHover);                 // (51)
        public static Bitmap kanoraHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.kanoraHover);                 // (52)
        public static Bitmap wironHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.wironHover);                  // (53)
        public static Bitmap urnaHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.urnaHover);                   // (54)
        public static Bitmap chrismHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.chrismHover);                 // (55)
        public static Bitmap antagonisticCliticHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.antagonisticCliticHover);     // (56)
        public static Bitmap usisHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.usisHover);                   // (57)
        public static Bitmap uvielHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.uvielHover);                  // (58)
        public static Bitmap uzionHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.uzionHover);                  // (59)
        public static Bitmap dexinHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.dexinHover);                  // (60)
        public static Bitmap cooperativeCliticHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.cooperativeCliticHover);      // (61)
        public static Bitmap yaltaHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.yaltaHover);                  // (62)
        public static Bitmap backspaceHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.backspaceHover);              // (63)
        public static Bitmap eshnaHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.eshnaHover);                  // (64)
        public static Bitmap cliticHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.cliticHover);                 // (65)
        public static Bitmap circleHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.circleHover);                 // (66)
        public static Bitmap deleteHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.deleteHover);                 // (67)
        public static Bitmap yamenHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.yamenHover);                  // (68)
        public static Bitmap dualCliticHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.dualCliticHover);             // (69)
        public static Bitmap squareHover = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.squareHover);                 // (70)

        public static Bitmap arrows_Hover_Left = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.arrows_Hover_Left);      // (01)
        public static Bitmap arrows_Hover_Up = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.arrows_Hover_Up);          // (02)
        public static Bitmap arrows_Hover_Right = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.arrows_Hover_Right);    // (03)
        public static Bitmap arrows_Hover_Down = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.arrows_Hover_Down);      // (04)

        public static Bitmap capital_KeyDown_Open_Bracket = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Open_Bracket);                 // (01)
        public static Bitmap capital_KeyDown_Jyam = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Jyam);                   // (02)
        public static Bitmap capital_KeyDown_Jzhad = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Jzhad);                  // (03)
        public static Bitmap capital_KeyDown_Closed_Bracket = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Closed_Bracket);                  // (04)
        public static Bitmap capital_KeyDown_Kehta = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Kehta);                  // (05)
        public static Bitmap capital_KeyDown_Ader = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Ader);                   // (06)
        public static Bitmap capital_KeyDown_Alna = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Alna);                   // (07)
        public static Bitmap capital_KeyDown_Percent_Sign = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Percent_Sign);                 // (08)
        public static Bitmap capital_KeyDown_Amien = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Amien);                  // (09)
        public static Bitmap capital_KeyDown_Athus = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Athus);                  // (10)
        public static Bitmap capital_KeyDown_Haxt = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Haxt);                   // (11)
        public static Bitmap capital_KeyDown_Bar = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Bar);                  // (12)
        public static Bitmap capital_KeyDown_Harux = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Harux);                  // (13)
        public static Bitmap capital_KeyDown_Ra = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Ra);                     // (14)
        public static Bitmap capital_KeyDown_Ren = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Ren);                    // (15)
        public static Bitmap capital_KeyDown_Ris = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Ris);                    // (16)
        public static Bitmap capital_KeyDown_Under_Score = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Under_Score);                  // (17)
        public static Bitmap capital_KeyDown_Barta = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Barta);                  // (18)
        public static Bitmap capital_KeyDown_Seto = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Seto);                   // (19)
        public static Bitmap capital_KeyDown_Karthon = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Karthon);                  // (20)
        public static Bitmap capital_KeyDown_Dolus = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Dolus);                  // (21)
        public static Bitmap capital_KeyDown_Tilda = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Tilda);                 // (22)
        public static Bitmap capital_KeyDown_Gamin = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Gamin);                  // (23)
        public static Bitmap capital_KeyDown_Payter = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Payter);                 // (24)
        public static Bitmap capital_KeyDown_Toma = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Toma);                   // (25)
        public static Bitmap capital_KeyDown_Tris = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Tris);                   // (26)
        public static Bitmap capital_KeyDown_Tyel = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Tyel);                   // (27)
        public static Bitmap capital_KeyDown_Vex = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Vex);                    // (28)
        public static Bitmap capital_KeyDown_Azium = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Azium);                  // (29)
        public static Bitmap capital_KeyDown_Efelid = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Efelid);                 // (30)
        public static Bitmap capital_KeyDown_Esis = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Esis);                   // (31)
        public static Bitmap capital_KeyDown_Fearon = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Fearon);                 // (32)
        public static Bitmap capital_KeyDown_Lodus = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Lodus);                  // (33)
        public static Bitmap capital_KeyDown_Memon = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Memon);                  // (34)
        public static Bitmap capital_KeyDown_Nefron = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Nefron);                 // (35)
        public static Bitmap capital_KeyDown_Nonum = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Nonum);                  // (36)
        public static Bitmap capital_KeyDown_Sola = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Sola);                   // (37)
        public static Bitmap capital_KeyDown_Diamond = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Diamond);                // (38)
        public static Bitmap capital_KeyDown_Suden = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Suden);                  // (39)
        public static Bitmap capital_KeyDown_Exo = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Exo);                    // (40)
        public static Bitmap capital_KeyDown_Ilunum = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Ilunum);                 // (41)
        public static Bitmap capital_KeyDown_Ixium = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Ixium);                  // (42)
        public static Bitmap capital_KeyDown_Oberon = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Oberon);                 // (43)
        public static Bitmap capital_KeyDown_Equals = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Equals);                  // (44)
        public static Bitmap capital_KeyDown_Open_Pointed_Bracket = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Open_Pointed_Bracket);                  // (45)
        public static Bitmap capital_KeyDown_Ocillum = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Ocillum);                // (46)
        public static Bitmap capital_KeyDown_Ojium = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Ojium);                  // (47)
        public static Bitmap capital_KeyDown_Opsen = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Opsen);                  // (48)
        public static Bitmap capital_KeyDown_Ortheks = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Ortheks);                // (49)
        public static Bitmap capital_KeyDown_Plus = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Plus);                 // (50)
        public static Bitmap capital_KeyDown_Close_Pointed_Bracket = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Close_Pointed_Bracket);                 // (51)
        public static Bitmap capital_KeyDown_Kanora = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Kanora);                 // (52)
        public static Bitmap capital_KeyDown_Wiron = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Wiron);                  // (53)
        public static Bitmap capital_KeyDown_Urna = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Urna);                   // (54)
        public static Bitmap capital_KeyDown_Minus = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Minus);                 // (55)
        public static Bitmap capital_KeyDown_Open_Parenthesis = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Open_Parenthesis);     // (56)
        public static Bitmap capital_KeyDown_Usis = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Usis);                   // (57)
        public static Bitmap capital_KeyDown_Uviel = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Uviel);                  // (58)
        public static Bitmap capital_KeyDown_Uzion = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Uzion);                  // (59)
        public static Bitmap capital_KeyDown_Asterix = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Asterix);                  // (60)
        public static Bitmap capital_KeyDown_Close_Parenthesis = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Close_Parenthesis);      // (61)
        public static Bitmap capital_KeyDown_Yalta = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Yalta);                  // (62)
        public static Bitmap capital_KeyDown_Backspace = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Backspace);              // (63)
        public static Bitmap capital_KeyDown_Forward_Slash = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Forward_Slash);                  // (64)
        public static Bitmap capital_KeyDown_Open_Square_Bracket = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Open_Square_Bracket);                 // (65)
        public static Bitmap capital_KeyDown_Circle = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Circle);                 // (66)
        public static Bitmap capital_KeyDown_Delete = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Delete);                 // (67)
        public static Bitmap capital_KeyDown_Backward_Slash = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Backward_Slash);                  // (68)
        public static Bitmap capital_KeyDown_Close_Square_Bracket = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Close_Square_Bracket);             // (69)
        public static Bitmap capital_KeyDown_Square = new System.Drawing.Bitmap(global::Keyboard_1.Properties.Resources.capital_KeyDown_Square);                 // (70)

        public static bool capitalizationState { get; set; }
        public void CreateComponents()
        {
            imageDict.Add(0, pholimDown);
            imageDict.Add(1, jyamDown);
            imageDict.Add(2, jzhadDown);
            imageDict.Add(3, nexusDown);
            imageDict.Add(4, kehtaDown);
            imageDict.Add(5, aderDown);
            imageDict.Add(6, alnaDown);
            imageDict.Add(7, thatusDown);
            imageDict.Add(8, amienDown);
            imageDict.Add(9, athusDown);
            imageDict.Add(10, haxtDown);
            imageDict.Add(11, venikDown);
            imageDict.Add(12, haruxDown);
            imageDict.Add(13, raDown);
            imageDict.Add(14, renDown);
            imageDict.Add(15, risDown);
            imageDict.Add(16, barimDown);
            imageDict.Add(17, bartaDown);
            imageDict.Add(18, setoDown);
            imageDict.Add(19, karthonDown);
            imageDict.Add(20, dolusDown);
            imageDict.Add(21, jensisDown);
            imageDict.Add(22, gaminDown);
            imageDict.Add(23, payterDown);
            imageDict.Add(24, tomaDown);
            imageDict.Add(25, trisDown);
            imageDict.Add(26, tyelDown);
            imageDict.Add(27, vexDown);
            imageDict.Add(28, aziumDown);
            imageDict.Add(29, efelidDown);
            imageDict.Add(30, esisDown);
            imageDict.Add(31, fearonDown);
            imageDict.Add(32, lodusDown);
            imageDict.Add(33, memonDown);
            imageDict.Add(34, nefronDown);
            imageDict.Add(35, nonumDown);
            imageDict.Add(36, solaDown);
            imageDict.Add(37, diamondDown);
            imageDict.Add(38, sudenDown);
            imageDict.Add(39, exoDown);
            imageDict.Add(40, ilunumDown);
            imageDict.Add(41, ixiumDown);
            imageDict.Add(42, oberonDown);
            imageDict.Add(43, odiumDown);
            imageDict.Add(44, commaDown);
            imageDict.Add(45, ocillumDown);
            imageDict.Add(46, ojiumDown);
            imageDict.Add(47, opsenDown);
            imageDict.Add(48, ortheksDown);
            imageDict.Add(49, parsusDown);
            imageDict.Add(50, periodDown);
            imageDict.Add(51, kanoraDown);
            imageDict.Add(52, wironDown);
            imageDict.Add(53, urnaDown);
            imageDict.Add(54, chrismDown);
            imageDict.Add(55, antagonisticCliticDown);
            imageDict.Add(56, usisDown);
            imageDict.Add(57, uvielDown);
            imageDict.Add(58, uzionDown);
            imageDict.Add(59, dexinDown);
            imageDict.Add(60, cooperativeCliticDown);
            imageDict.Add(61, yaltaDown);
            imageDict.Add(62, backspaceDown);
            imageDict.Add(63, eshnaDown);
            imageDict.Add(64, cliticDown);
            imageDict.Add(65, circleDown);
            imageDict.Add(66, deleteDown);
            imageDict.Add(67, yamenDown);
            imageDict.Add(68, dualCliticDown);
            imageDict.Add(69, squareDown);
       }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void threadStarter()
        {
            BackEnd be1 = new BackEnd();                                                                // make an object of the thread class
            Thread threadID1 = new Thread(new ThreadStart(be1.CreateComponents));
            threadID1.Start();
        }

        [STAThread]
        static void Main()
        {
            threadStarter();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Onscreen_Keyboard());


        }
    }
}
