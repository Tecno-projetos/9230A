using _9230A_V00___PI.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace _9230A_V00___PI.Equipamentos
{
    /// <summary>
    /// Interação lógica para elevadorDireita.xam
    /// </summary>
    public partial class elevadorDireita : UserControl
    {

        #region Variables

        Utilidades.EquipsControl equip;

        bool loadedEquip = false;

        bool Aux_StoryBoard = true;

        Storyboard Elevador_Sobe;
        Storyboard Elevador_Desce;

        //================================================================================================================================
        //Head
        LinearGradientBrush VM = new LinearGradientBrush();
        LinearGradientBrush AM = new LinearGradientBrush();
        LinearGradientBrush AZ = new LinearGradientBrush();
        LinearGradientBrush VD = new LinearGradientBrush();
        LinearGradientBrush VD_1 = new LinearGradientBrush();
        LinearGradientBrush CZ = new LinearGradientBrush();
        LinearGradientBrush VM1 = new LinearGradientBrush();
        LinearGradientBrush AM1 = new LinearGradientBrush();
        LinearGradientBrush AZ1 = new LinearGradientBrush();
        LinearGradientBrush VD1 = new LinearGradientBrush();
        LinearGradientBrush VD1_1 = new LinearGradientBrush();
        LinearGradientBrush CZ1 = new LinearGradientBrush();
        LinearGradientBrush LJ = new LinearGradientBrush();
        LinearGradientBrush LJ_1 = new LinearGradientBrush();

        //Foot
        LinearGradientBrush VM_Foot = new LinearGradientBrush();
        LinearGradientBrush AM_Foot = new LinearGradientBrush();
        LinearGradientBrush AZ_Foot = new LinearGradientBrush();
        LinearGradientBrush VD_Foot = new LinearGradientBrush();
        LinearGradientBrush VD_1_Foot = new LinearGradientBrush();
        LinearGradientBrush CZ_Foot = new LinearGradientBrush();
        LinearGradientBrush LJ_Foot = new LinearGradientBrush();

        //Body
        LinearGradientBrush VM_Body = new LinearGradientBrush();
        LinearGradientBrush AM_Body = new LinearGradientBrush();
        LinearGradientBrush AZ_Body = new LinearGradientBrush();
        LinearGradientBrush VD_Body = new LinearGradientBrush();
        LinearGradientBrush VD_1_Body = new LinearGradientBrush();
        LinearGradientBrush CZ_Body = new LinearGradientBrush();
        LinearGradientBrush LJ_Body = new LinearGradientBrush();

        //================================================================================================================================

        bool ticktack = false;

        #endregion


        public elevadorDireita()
        {
            InitializeComponent();

            #region Create LinearGradientBrush Head

            LJ.GradientStops.Add(new GradientStop(Color.FromRgb(255, 150, 0), 0.0));
            LJ.GradientStops.Add(new GradientStop(Color.FromRgb(218, 218, 218), 0.5));
            LJ.GradientStops.Add(new GradientStop(Color.FromRgb(255, 150, 0), 1.0));

            RotateTransform rot00 = new RotateTransform();
            rot00.Angle = 90;
            rot00.CenterX = 0.5;
            rot00.CenterY = 0.5;

            TransformGroup tgroup00 = new TransformGroup();
            tgroup00.Children.Add(rot00);

            LJ.RelativeTransform = tgroup00;

            //================================================================================================================================

            VM.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0.0));
            VM.GradientStops.Add(new GradientStop(Color.FromRgb(255, 160, 160), 0.5));
            VM.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 1.0));

            RotateTransform rot = new RotateTransform();
            rot.Angle = 90;
            rot.CenterX = 0.5;
            rot.CenterY = 0.5;

            TransformGroup tgroup = new TransformGroup();
            tgroup.Children.Add(rot);

            VM.RelativeTransform = tgroup;

            //================================================================================================================================

            AM.GradientStops.Add(new GradientStop(Color.FromRgb(200, 200, 0), 0.0));
            AM.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 150), 0.5));
            AM.GradientStops.Add(new GradientStop(Color.FromRgb(200, 200, 0), 1.0));

            RotateTransform rot1 = new RotateTransform();
            rot1.Angle = 90;
            rot1.CenterX = 0.5;
            rot1.CenterY = 0.5;

            TransformGroup tgroup1 = new TransformGroup();
            tgroup1.Children.Add(rot1);

            AM.RelativeTransform = tgroup1;

            //================================================================================================================================

            AZ.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 0.0));
            AZ.GradientStops.Add(new GradientStop(Color.FromRgb(160, 160, 255), 0.5));
            AZ.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 1.0));

            RotateTransform rot2 = new RotateTransform();
            rot2.Angle = 90;
            rot2.CenterX = 0.5;
            rot2.CenterY = 0.5;

            TransformGroup tgroup2 = new TransformGroup();
            tgroup2.Children.Add(rot2);

            AZ.RelativeTransform = tgroup2;

            //================================================================================================================================

            VD.GradientStops.Add(new GradientStop(Color.FromRgb(0, 100, 0), 0.0));
            VD.GradientStops.Add(new GradientStop(Color.FromRgb(160, 255, 160), 0.5));
            VD.GradientStops.Add(new GradientStop(Color.FromRgb(0, 100, 0), 1.0));

            RotateTransform rot3 = new RotateTransform();
            rot3.Angle = 90;
            rot3.CenterX = 0.5;
            rot3.CenterY = 0.5;

            TransformGroup tgroup3 = new TransformGroup();
            tgroup3.Children.Add(rot3);

            VD.RelativeTransform = tgroup3;

            //================================================================================================================================

            VD_1.GradientStops.Add(new GradientStop(Color.FromRgb(0, 150, 0), 0.0));
            VD_1.GradientStops.Add(new GradientStop(Color.FromRgb(190, 255, 190), 0.5));
            VD_1.GradientStops.Add(new GradientStop(Color.FromRgb(0, 150, 0), 1.0));

            RotateTransform rot11 = new RotateTransform();
            rot11.Angle = 90;
            rot11.CenterX = 0.5;
            rot11.CenterY = 0.5;

            TransformGroup tgroup11 = new TransformGroup();
            tgroup11.Children.Add(rot11);

            VD_1.RelativeTransform = tgroup11;

            //================================================================================================================================

            CZ.GradientStops.Add(new GradientStop(Color.FromRgb(80, 80, 80), 0.0));
            CZ.GradientStops.Add(new GradientStop(Color.FromRgb(200, 200, 200), 0.5));
            CZ.GradientStops.Add(new GradientStop(Color.FromRgb(80, 80, 80), 1.0));

            RotateTransform rot4 = new RotateTransform();
            rot4.Angle = 90;
            rot4.CenterX = 0.5;
            rot4.CenterY = 0.5;

            TransformGroup tgroup4 = new TransformGroup();
            tgroup4.Children.Add(rot4);

            CZ.RelativeTransform = tgroup4;

            //================================================================================================================================

            VM1.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0.0));
            VM1.GradientStops.Add(new GradientStop(Color.FromRgb(255, 160, 160), 0.5));
            VM1.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 1.0));

            RotateTransform rot5 = new RotateTransform();
            rot5.Angle = 166;
            rot5.CenterX = 0.5;
            rot5.CenterY = 0.5;

            TransformGroup tgroup5 = new TransformGroup();
            tgroup5.Children.Add(rot5);

            VM1.RelativeTransform = tgroup5;

            //================================================================================================================================

            AM1.GradientStops.Add(new GradientStop(Color.FromRgb(200, 200, 0), 0.0));
            AM1.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 150), 0.5));
            AM1.GradientStops.Add(new GradientStop(Color.FromRgb(200, 200, 0), 1.0));

            RotateTransform rot6 = new RotateTransform();
            rot6.Angle = 166;
            rot6.CenterX = 0.5;
            rot6.CenterY = 0.5;

            TransformGroup tgroup6 = new TransformGroup();
            tgroup6.Children.Add(rot6);

            AM1.RelativeTransform = tgroup6;

            //================================================================================================================================

            AZ1.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 0.0));
            AZ1.GradientStops.Add(new GradientStop(Color.FromRgb(160, 160, 255), 0.5));
            AZ1.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 1.0));

            RotateTransform rot7 = new RotateTransform();
            rot7.Angle = 166;
            rot7.CenterX = 0.5;
            rot7.CenterY = 0.5;

            TransformGroup tgroup7 = new TransformGroup();
            tgroup7.Children.Add(rot7);

            AZ1.RelativeTransform = tgroup7;

            //================================================================================================================================

            VD1.GradientStops.Add(new GradientStop(Color.FromRgb(0, 100, 0), 0.0));
            VD1.GradientStops.Add(new GradientStop(Color.FromRgb(160, 255, 160), 0.5));
            VD1.GradientStops.Add(new GradientStop(Color.FromRgb(0, 100, 0), 1.0));

            RotateTransform rot8 = new RotateTransform();
            rot8.Angle = 166;
            rot8.CenterX = 0.5;
            rot8.CenterY = 0.5;

            TransformGroup tgroup8 = new TransformGroup();
            tgroup8.Children.Add(rot8);

            VD1.RelativeTransform = tgroup8;

            //================================================================================================================================

            CZ1.GradientStops.Add(new GradientStop(Color.FromRgb(80, 80, 80), 0.0));
            CZ1.GradientStops.Add(new GradientStop(Color.FromRgb(200, 200, 200), 0.5));
            CZ1.GradientStops.Add(new GradientStop(Color.FromRgb(80, 80, 80), 1.0));

            RotateTransform rot9 = new RotateTransform();
            rot9.Angle = 166;
            rot9.CenterX = 0.5;
            rot9.CenterY = 0.5;

            TransformGroup tgroup9 = new TransformGroup();
            tgroup9.Children.Add(rot9);

            CZ1.RelativeTransform = tgroup9;

            //================================================================================================================================

            VD1_1.GradientStops.Add(new GradientStop(Color.FromRgb(0, 150, 0), 0.0));
            VD1_1.GradientStops.Add(new GradientStop(Color.FromRgb(190, 255, 190), 0.5));
            VD1_1.GradientStops.Add(new GradientStop(Color.FromRgb(0, 150, 0), 1.0));

            RotateTransform rot10 = new RotateTransform();
            rot10.Angle = 166;
            rot10.CenterX = 0.5;
            rot10.CenterY = 0.5;

            TransformGroup tgroup10 = new TransformGroup();
            tgroup10.Children.Add(rot10);

            VD1_1.RelativeTransform = tgroup10;

            //================================================================================================================================

            LJ_1.GradientStops.Add(new GradientStop(Color.FromRgb(255, 150, 0), 0.0));
            LJ_1.GradientStops.Add(new GradientStop(Color.FromRgb(218, 218, 218), 0.5));
            LJ_1.GradientStops.Add(new GradientStop(Color.FromRgb(255, 150, 0), 1.0));

            RotateTransform rot000 = new RotateTransform();
            rot000.Angle = 166;
            rot000.CenterX = 0.5;
            rot000.CenterY = 0.5;

            TransformGroup tgroup000 = new TransformGroup();
            tgroup000.Children.Add(rot000);

            LJ_1.RelativeTransform = tgroup000;

            #endregion

            #region Create LinearGradientBrush Body 

            LJ_Body.GradientStops.Add(new GradientStop(Color.FromRgb(255, 150, 0), 0.0));
            LJ_Body.GradientStops.Add(new GradientStop(Color.FromRgb(218, 218, 218), 0.5));
            LJ_Body.GradientStops.Add(new GradientStop(Color.FromRgb(255, 150, 0), 1.0));

            RotateTransform rot30 = new RotateTransform();
            rot30.Angle = 90;
            rot30.CenterX = 0.5;
            rot30.CenterY = 0.5;

            TransformGroup tgroup30 = new TransformGroup();
            tgroup30.Children.Add(rot30);

            LJ_Body.RelativeTransform = tgroup30;

            //================================================================================================================================

            VM_Body.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0.0));
            VM_Body.GradientStops.Add(new GradientStop(Color.FromRgb(255, 160, 160), 0.5));
            VM_Body.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 1.0));

            RotateTransform rot31 = new RotateTransform();
            rot31.Angle = 90;
            rot31.CenterX = 0.5;
            rot31.CenterY = 0.5;

            TransformGroup tgroup31 = new TransformGroup();
            tgroup31.Children.Add(rot31);

            VM_Body.RelativeTransform = tgroup31;

            //================================================================================================================================

            AM_Body.GradientStops.Add(new GradientStop(Color.FromRgb(200, 200, 0), 0.0));
            AM_Body.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 150), 0.5));
            AM_Body.GradientStops.Add(new GradientStop(Color.FromRgb(200, 200, 0), 1.0));

            RotateTransform rot32 = new RotateTransform();
            rot32.Angle = 90;
            rot32.CenterX = 0.5;
            rot32.CenterY = 0.5;

            TransformGroup tgroup32 = new TransformGroup();
            tgroup32.Children.Add(rot32);

            AM_Body.RelativeTransform = tgroup32;

            //================================================================================================================================

            AZ_Body.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 0.0));
            AZ_Body.GradientStops.Add(new GradientStop(Color.FromRgb(160, 160, 255), 0.5));
            AZ_Body.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 1.0));

            RotateTransform rot33 = new RotateTransform();
            rot33.Angle = 90;
            rot33.CenterX = 0.5;
            rot33.CenterY = 0.5;

            TransformGroup tgroup33 = new TransformGroup();
            tgroup33.Children.Add(rot33);

            AZ_Body.RelativeTransform = tgroup33;

            //================================================================================================================================

            VD_Body.GradientStops.Add(new GradientStop(Color.FromRgb(0, 100, 0), 0.0));
            VD_Body.GradientStops.Add(new GradientStop(Color.FromRgb(160, 255, 160), 0.5));
            VD_Body.GradientStops.Add(new GradientStop(Color.FromRgb(0, 100, 0), 1.0));

            RotateTransform rot34 = new RotateTransform();
            rot34.Angle = 90;
            rot34.CenterX = 0.5;
            rot34.CenterY = 0.5;

            TransformGroup tgroup34 = new TransformGroup();
            tgroup34.Children.Add(rot34);

            VD_Body.RelativeTransform = tgroup34;

            //================================================================================================================================

            VD_1_Body.GradientStops.Add(new GradientStop(Color.FromRgb(0, 150, 0), 0.0));
            VD_1_Body.GradientStops.Add(new GradientStop(Color.FromRgb(190, 255, 190), 0.5));
            VD_1_Body.GradientStops.Add(new GradientStop(Color.FromRgb(0, 150, 0), 1.0));

            RotateTransform rot35 = new RotateTransform();
            rot35.Angle = 90;
            rot35.CenterX = 0.5;
            rot35.CenterY = 0.5;

            TransformGroup tgroup35 = new TransformGroup();
            tgroup35.Children.Add(rot35);

            VD_1_Body.RelativeTransform = tgroup35;



            //================================================================================================================================

            CZ_Body.GradientStops.Add(new GradientStop(Color.FromRgb(80, 80, 80), 0.0));
            CZ_Body.GradientStops.Add(new GradientStop(Color.FromRgb(200, 200, 200), 0.5));
            CZ_Body.GradientStops.Add(new GradientStop(Color.FromRgb(80, 80, 80), 1.0));

            RotateTransform rot36 = new RotateTransform();
            rot36.Angle = 90;
            rot36.CenterX = 0.5;
            rot36.CenterY = 0.5;

            TransformGroup tgroup36 = new TransformGroup();
            tgroup36.Children.Add(rot36);

            CZ_Body.RelativeTransform = tgroup36;

            //================================================================================================================================

            #endregion

            #region Create LinearGradientBrush Foot

            LJ_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(255, 150, 0), 0.0));
            LJ_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(218, 218, 218), 0.5));
            LJ_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(255, 150, 0), 1.0));

            RotateTransform rot20 = new RotateTransform();
            rot20.Angle = 130;
            rot20.CenterX = 0.5;
            rot20.CenterY = 0.5;

            TransformGroup tgroup20 = new TransformGroup();
            tgroup20.Children.Add(rot20);

            LJ_Foot.RelativeTransform = tgroup20;

            //================================================================================================================================

            VM_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0.0));
            VM_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(255, 160, 160), 0.5));
            VM_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 1.0));

            RotateTransform rot21 = new RotateTransform();
            rot21.Angle = 130;
            rot21.CenterX = 0.5;
            rot21.CenterY = 0.5;

            TransformGroup tgroup21 = new TransformGroup();
            tgroup21.Children.Add(rot21);

            VM_Foot.RelativeTransform = tgroup21;

            //================================================================================================================================

            AM_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(200, 200, 0), 0.0));
            AM_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 150), 0.5));
            AM_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(200, 200, 0), 1.0));

            RotateTransform rot22 = new RotateTransform();
            rot22.Angle = 130;
            rot22.CenterX = 0.5;
            rot22.CenterY = 0.5;

            TransformGroup tgroup22 = new TransformGroup();
            tgroup22.Children.Add(rot22);

            AM_Foot.RelativeTransform = tgroup22;

            //================================================================================================================================

            AZ_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 0.0));
            AZ_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(160, 160, 255), 0.5));
            AZ_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 1.0));

            RotateTransform rot23 = new RotateTransform();
            rot23.Angle = 130;
            rot23.CenterX = 0.5;
            rot23.CenterY = 0.5;

            TransformGroup tgroup23 = new TransformGroup();
            tgroup23.Children.Add(rot23);

            AZ_Foot.RelativeTransform = tgroup23;

            //================================================================================================================================

            VD_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(0, 100, 0), 0.0));
            VD_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(160, 255, 160), 0.5));
            VD_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(0, 100, 0), 1.0));

            RotateTransform rot24 = new RotateTransform();
            rot24.Angle = 130;
            rot24.CenterX = 0.5;
            rot24.CenterY = 0.5;

            TransformGroup tgroup24 = new TransformGroup();
            tgroup24.Children.Add(rot24);

            VD_Foot.RelativeTransform = tgroup24;

            //================================================================================================================================

            VD_1_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(0, 150, 0), 0.0));
            VD_1_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(190, 255, 190), 0.5));
            VD_1_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(0, 150, 0), 1.0));

            RotateTransform rot25 = new RotateTransform();
            rot25.Angle = 130;
            rot25.CenterX = 0.5;
            rot25.CenterY = 0.5;

            TransformGroup tgroup25 = new TransformGroup();
            tgroup25.Children.Add(rot25);

            VD_1_Foot.RelativeTransform = tgroup25;

            //================================================================================================================================

            CZ_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(80, 80, 80), 0.0));
            CZ_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(200, 200, 200), 0.5));
            CZ_Foot.GradientStops.Add(new GradientStop(Color.FromRgb(80, 80, 80), 1.0));

            RotateTransform rot26 = new RotateTransform();
            rot26.Angle = 130;
            rot26.CenterX = 0.5;
            rot26.CenterY = 0.5;

            TransformGroup tgroup26 = new TransformGroup();
            tgroup26.Children.Add(rot26);

            CZ_Foot.RelativeTransform = tgroup26;

            //================================================================================================================================

            #endregion

            #region StoryBoard Configuration

            Elevador_Sobe = (Storyboard)this.Resources["Elevador_Direito_Sobe"];
            Elevador_Sobe.Completed += new EventHandler(Elevador_Direito_Sobe_Completed);

            Elevador_Desce = (Storyboard)this.Resources["Elevador_Direito_Desce"];
            Elevador_Desce.Completed += new EventHandler(Elevador_Direito_Desce_Completed);

            Elevador_Sobe.Stop();
            Elevador_Desce.Stop();

            #endregion

            this.PreviewMouseLeftButtonUp += ElevadorDireita_PreviewMouseLeftButtonUp;
        }

        private void ElevadorDireita_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            equip.OpenWindow();
        }

        #region StoryBoard

        private void Elevador_Direito_Desce_Completed(object sender, EventArgs e)
        {
            if (!Aux_StoryBoard)
            {
                Elevador_Desce.Begin();
            }
            else
            {
                Elevador_Desce.Stop();
            }

        }

        private void Elevador_Direito_Sobe_Completed(object sender, EventArgs e)
        {
            if (!Aux_StoryBoard)
            {
                Elevador_Sobe.Begin();
            }
            else
            {
                Elevador_Sobe.Stop();
            }

        }

        #endregion  

        public void loadEquip(typeEquip Equip, typeCommand TCommand, int initialOffSet, int bufferPlc, string nome, string tag, string numeroPartida, string paginaProjeto)
        {
            equip = new EquipsControl(Equip, TCommand, initialOffSet, bufferPlc, nome, tag, numeroPartida, paginaProjeto);
            loadedEquip = true;
        }
        public EquipsControl Equip_GS { get => equip; }
        public void actualize_UI()
        {
            if (loadedEquip)
            {
                if (!equip.Command_Get.Standard.Emergencia)
                {
                    Head_1.Dispatcher.BeginInvoke((Action)(() => Head_1.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0))));
                    Head_2.Dispatcher.BeginInvoke((Action)(() => Head_2.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0))));
                    Head_3.Dispatcher.BeginInvoke((Action)(() => Head_3.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0))));
                    Head_4.Dispatcher.BeginInvoke((Action)(() => Head_4.Fill = VM));
                    Head_7.Dispatcher.BeginInvoke((Action)(() => Head_7.Fill = VM));
                    Head_6.Dispatcher.BeginInvoke((Action)(() => Head_6.Fill = VM));
                    Head_8.Dispatcher.BeginInvoke((Action)(() => Head_8.Fill = VM1));

                    Body1.Dispatcher.Invoke(delegate { Body1.Fill = VM_Body; });
                    Body2.Dispatcher.Invoke(delegate { Body2.Fill = VM_Body; });

                    Foot1.Dispatcher.Invoke(delegate { Foot1.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0)); });
                    //Foot2.Dispatcher.Invoke(delegate { Foot2.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0)); });
                    Foot3.Dispatcher.Invoke(delegate { Foot3.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0)); });
                    Foot4.Dispatcher.Invoke(delegate { Foot4.Fill = VM_Foot; });

                }
                else if (equip.Command_Get.Standard.Falha_Geral)
                {
                    if (ticktack)
                    {
                        Head_1.Dispatcher.BeginInvoke((Action)(() => Head_1.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0))));
                        Head_2.Dispatcher.BeginInvoke((Action)(() => Head_2.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0))));
                        Head_3.Dispatcher.BeginInvoke((Action)(() => Head_3.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0))));
                        Head_4.Dispatcher.BeginInvoke((Action)(() => Head_4.Fill = VM));
                        Head_7.Dispatcher.BeginInvoke((Action)(() => Head_7.Fill = VM));
                        Head_6.Dispatcher.BeginInvoke((Action)(() => Head_6.Fill = VM));
                        Head_8.Dispatcher.BeginInvoke((Action)(() => Head_8.Fill = VM1));

                        Body1.Dispatcher.Invoke(delegate { Body1.Fill = VM_Body; });
                        Body2.Dispatcher.Invoke(delegate { Body2.Fill = VM_Body; });

                        Foot1.Dispatcher.Invoke(delegate { Foot1.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0)); });
                        //Foot2.Dispatcher.Invoke(delegate { Foot2.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0)); });
                        Foot3.Dispatcher.Invoke(delegate { Foot3.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0)); });
                        Foot4.Dispatcher.Invoke(delegate { Foot4.Fill = VM_Foot; });
                    }
                    else
                    {
                        Head_1.Dispatcher.BeginInvoke((Action)(() => Head_1.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80))));
                        Head_2.Dispatcher.BeginInvoke((Action)(() => Head_2.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80))));
                        Head_3.Dispatcher.BeginInvoke((Action)(() => Head_3.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80))));
                        Head_4.Dispatcher.BeginInvoke((Action)(() => Head_4.Fill = CZ));
                        Head_7.Dispatcher.BeginInvoke((Action)(() => Head_7.Fill = CZ));
                        Head_6.Dispatcher.BeginInvoke((Action)(() => Head_6.Fill = CZ));
                        Head_8.Dispatcher.BeginInvoke((Action)(() => Head_8.Fill = CZ1));

                        Body1.Dispatcher.Invoke(delegate { Body1.Fill = CZ_Body; });
                        Body2.Dispatcher.Invoke(delegate { Body2.Fill = CZ_Body; });

                        Foot1.Dispatcher.Invoke(delegate { Foot1.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80)); });
                        //Foot2.Dispatcher.Invoke(delegate { Foot2.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80)); });
                        Foot3.Dispatcher.Invoke(delegate { Foot3.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80)); });
                        Foot4.Dispatcher.Invoke(delegate { Foot4.Fill = CZ_Foot; });
                    }
                }
                else if (equip.Command_Get.Standard.Manutencao)
                {
                    Head_1.Dispatcher.BeginInvoke((Action)(() => Head_1.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 255))));
                    Head_2.Dispatcher.BeginInvoke((Action)(() => Head_2.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 255))));
                    Head_3.Dispatcher.BeginInvoke((Action)(() => Head_3.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 255))));
                    Head_4.Dispatcher.BeginInvoke((Action)(() => Head_4.Fill = AZ));
                    Head_7.Dispatcher.BeginInvoke((Action)(() => Head_7.Fill = AZ));
                    Head_6.Dispatcher.BeginInvoke((Action)(() => Head_6.Fill = AZ));
                    Head_8.Dispatcher.BeginInvoke((Action)(() => Head_8.Fill = AZ1));

                    Body1.Dispatcher.Invoke(delegate { Body1.Fill = AZ_Body; });
                    Body2.Dispatcher.Invoke(delegate { Body2.Fill = AZ_Body; });

                    Foot1.Dispatcher.Invoke(delegate { Foot1.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 255)); });
                    //Foot2.Dispatcher.Invoke(delegate { Foot2.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 255)); });
                    Foot3.Dispatcher.Invoke(delegate { Foot3.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 255)); });
                    Foot4.Dispatcher.Invoke(delegate { Foot4.Fill = AZ_Foot; });
                }
                else if (!equip.Command_Get.Standard.Liberado)
                {
                    Head_1.Dispatcher.BeginInvoke((Action)(() => Head_1.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0))));
                    Head_2.Dispatcher.BeginInvoke((Action)(() => Head_2.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0))));
                    Head_3.Dispatcher.BeginInvoke((Action)(() => Head_3.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0))));
                    Head_4.Dispatcher.BeginInvoke((Action)(() => Head_4.Fill = AM));
                    Head_7.Dispatcher.BeginInvoke((Action)(() => Head_7.Fill = AM));
                    Head_6.Dispatcher.BeginInvoke((Action)(() => Head_6.Fill = AM));
                    Head_8.Dispatcher.BeginInvoke((Action)(() => Head_8.Fill = AM1));

                    Body1.Dispatcher.Invoke(delegate { Body1.Fill = AM_Body; });
                    Body2.Dispatcher.Invoke(delegate { Body2.Fill = AM_Body; });

                    Foot1.Dispatcher.Invoke(delegate { Foot1.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0)); });
                    //Foot2.Dispatcher.Invoke(delegate { Foot2.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0)); });
                    Foot3.Dispatcher.Invoke(delegate { Foot3.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0)); });
                    Foot4.Dispatcher.Invoke(delegate { Foot4.Fill = AM_Foot; });



                }
                else if (equip.Command_Get.Standard.Ligando)
                {
                    if (ticktack)
                    {
                        Head_1.Dispatcher.BeginInvoke((Action)(() => Head_1.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0))));
                        Head_2.Dispatcher.BeginInvoke((Action)(() => Head_2.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0))));
                        Head_3.Dispatcher.BeginInvoke((Action)(() => Head_3.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0))));
                        Head_4.Dispatcher.BeginInvoke((Action)(() => Head_4.Fill = VD));
                        Head_7.Dispatcher.BeginInvoke((Action)(() => Head_7.Fill = VD));
                        Head_6.Dispatcher.BeginInvoke((Action)(() => Head_6.Fill = VD));
                        Head_8.Dispatcher.BeginInvoke((Action)(() => Head_8.Fill = VD1));

                        Body1.Dispatcher.Invoke(delegate { Body1.Fill = VD_1_Body; });
                        Body2.Dispatcher.Invoke(delegate { Body2.Fill = VD_1_Body; });

                        Foot1.Dispatcher.Invoke(delegate { Foot1.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0)); });
                        //Foot2.Dispatcher.Invoke(delegate { Foot2.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0)); });
                        Foot3.Dispatcher.Invoke(delegate { Foot3.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0)); });
                        Foot4.Dispatcher.Invoke(delegate { Foot4.Fill = VD_Foot; });

                    }
                    else
                    {
                        Head_1.Dispatcher.BeginInvoke((Action)(() => Head_1.Fill = new SolidColorBrush(Color.FromRgb(0, 190, 0))));
                        Head_2.Dispatcher.BeginInvoke((Action)(() => Head_2.Fill = new SolidColorBrush(Color.FromRgb(0, 190, 0))));
                        Head_3.Dispatcher.BeginInvoke((Action)(() => Head_3.Fill = new SolidColorBrush(Color.FromRgb(0, 190, 0))));
                        Head_4.Dispatcher.BeginInvoke((Action)(() => Head_4.Fill = VD_1));
                        Head_7.Dispatcher.BeginInvoke((Action)(() => Head_7.Fill = VD_1));
                        Head_6.Dispatcher.BeginInvoke((Action)(() => Head_6.Fill = VD_1));
                        Head_8.Dispatcher.BeginInvoke((Action)(() => Head_8.Fill = VD1_1));

                        Body1.Dispatcher.Invoke(delegate { Body1.Fill = VD_1_Body; });
                        Body2.Dispatcher.Invoke(delegate { Body2.Fill = VD_1_Body; });

                        Foot1.Dispatcher.Invoke(delegate { Foot1.Fill = new SolidColorBrush(Color.FromRgb(0, 190, 0)); });
                        //Foot2.Dispatcher.Invoke(delegate { Foot2.Fill = new SolidColorBrush(Color.FromRgb(0, 190, 0)); });
                        Foot3.Dispatcher.Invoke(delegate { Foot3.Fill = new SolidColorBrush(Color.FromRgb(0, 190, 0)); });
                        Foot4.Dispatcher.Invoke(delegate { Foot4.Fill = VD_1_Foot; });
                    }
                }
                else if (equip.Command_Get.Standard.Desligando)
                {
                    if (ticktack)
                    {
                        Head_1.Dispatcher.BeginInvoke((Action)(() => Head_1.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0))));
                        Head_2.Dispatcher.BeginInvoke((Action)(() => Head_2.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0))));
                        Head_3.Dispatcher.BeginInvoke((Action)(() => Head_3.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0))));
                        Head_4.Dispatcher.BeginInvoke((Action)(() => Head_4.Fill = VD));
                        Head_7.Dispatcher.BeginInvoke((Action)(() => Head_7.Fill = VD));
                        Head_6.Dispatcher.BeginInvoke((Action)(() => Head_6.Fill = VD));
                        Head_8.Dispatcher.BeginInvoke((Action)(() => Head_8.Fill = VD1));

                        Body1.Dispatcher.Invoke(delegate { Body1.Fill = VD_Body; });
                        Body2.Dispatcher.Invoke(delegate { Body2.Fill = VD_Body; });

                        Foot1.Dispatcher.Invoke(delegate { Foot1.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0)); });
                        //Foot2.Dispatcher.Invoke(delegate { Foot2.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0)); });
                        Foot3.Dispatcher.Invoke(delegate { Foot3.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0)); });
                        Foot4.Dispatcher.Invoke(delegate { Foot4.Fill = VD_Foot; });
                    }
                    else
                    {
                        Head_1.Dispatcher.BeginInvoke((Action)(() => Head_1.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80))));
                        Head_2.Dispatcher.BeginInvoke((Action)(() => Head_2.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80))));
                        Head_3.Dispatcher.BeginInvoke((Action)(() => Head_3.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80))));
                        Head_4.Dispatcher.BeginInvoke((Action)(() => Head_4.Fill = CZ));
                        Head_7.Dispatcher.BeginInvoke((Action)(() => Head_7.Fill = CZ));
                        Head_6.Dispatcher.BeginInvoke((Action)(() => Head_6.Fill = CZ));
                        Head_8.Dispatcher.BeginInvoke((Action)(() => Head_8.Fill = CZ1));

                        Body1.Dispatcher.Invoke(delegate { Body1.Fill = CZ_Body; });
                        Body2.Dispatcher.Invoke(delegate { Body2.Fill = CZ_Body; });

                        Foot1.Dispatcher.Invoke(delegate { Foot1.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80)); });
                        //Foot2.Dispatcher.Invoke(delegate { Foot2.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80)); });
                        Foot3.Dispatcher.Invoke(delegate { Foot3.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80)); });
                        Foot4.Dispatcher.Invoke(delegate { Foot4.Fill = CZ_Foot; });
                    }
                }
                else
                {
                    if (equip.Command_Get.Standard.Ligado)
                    {
                        Head_1.Dispatcher.BeginInvoke((Action)(() => Head_1.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0))));
                        Head_2.Dispatcher.BeginInvoke((Action)(() => Head_2.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0))));
                        Head_3.Dispatcher.BeginInvoke((Action)(() => Head_3.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0))));
                        Head_4.Dispatcher.BeginInvoke((Action)(() => Head_4.Fill = VD));
                        Head_7.Dispatcher.BeginInvoke((Action)(() => Head_7.Fill = VD));
                        Head_6.Dispatcher.BeginInvoke((Action)(() => Head_6.Fill = VD));
                        Head_8.Dispatcher.BeginInvoke((Action)(() => Head_8.Fill = VD1));

                        Body1.Dispatcher.Invoke(delegate { Body1.Fill = VD_Body; });
                        Body2.Dispatcher.Invoke(delegate { Body2.Fill = VD_Body; });

                        Foot1.Dispatcher.Invoke(delegate { Foot1.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0)); });
                        //Foot2.Dispatcher.Invoke(delegate { Foot2.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0)); });
                        Foot3.Dispatcher.Invoke(delegate { Foot3.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 0)); });
                        Foot4.Dispatcher.Invoke(delegate { Foot4.Fill = VD_Foot; });
                    }
                    else
                    {
                        Head_1.Dispatcher.BeginInvoke((Action)(() => Head_1.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80))));
                        Head_2.Dispatcher.BeginInvoke((Action)(() => Head_2.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80))));
                        Head_3.Dispatcher.BeginInvoke((Action)(() => Head_3.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80))));
                        Head_4.Dispatcher.BeginInvoke((Action)(() => Head_4.Fill = CZ));
                        Head_7.Dispatcher.BeginInvoke((Action)(() => Head_7.Fill = CZ));
                        Head_6.Dispatcher.BeginInvoke((Action)(() => Head_6.Fill = CZ));
                        Head_8.Dispatcher.BeginInvoke((Action)(() => Head_8.Fill = CZ1));

                        Body1.Dispatcher.Invoke(delegate { Body1.Fill = CZ_Body; });
                        Body2.Dispatcher.Invoke(delegate { Body2.Fill = CZ_Body; });

                        Foot1.Dispatcher.Invoke(delegate { Foot1.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80)); });
                        //Foot2.Dispatcher.Invoke(delegate { Foot2.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80)); });
                        Foot3.Dispatcher.Invoke(delegate { Foot3.Fill = new SolidColorBrush(Color.FromRgb(80, 80, 80)); });
                        Foot4.Dispatcher.Invoke(delegate { Foot4.Fill = CZ_Foot; });
                    }
                }

                ticktack = !ticktack;

                #region Names

                if (equip.Command_Get.Standard.Automatico)
                {
                    LB_M_A.Dispatcher.BeginInvoke((Action)(() => LB_M_A.Content = "A"));

                }
                else
                {
                    LB_M_A.Dispatcher.BeginInvoke((Action)(() => LB_M_A.Content = "M"));
                }

                #endregion

                #region StoryBoard

                if (equip.Command_Get.Standard.Ligado)
                {
                    if (Aux_StoryBoard)
                    {
                        Elevador_Desce.Dispatcher.BeginInvoke((Action)(() => Elevador_Desce.Begin()));
                        Elevador_Sobe.Dispatcher.BeginInvoke((Action)(() => Elevador_Sobe.Begin()));
                        Aux_StoryBoard = false;
                    }
                }
                else
                {
                    if (!Aux_StoryBoard)
                    {
                        Aux_StoryBoard = true;
                    }
                }
                #endregion
            }
        }

        public bool actualize_Equip
        {
            set
            {
                if (loadedEquip)
                {
                    //Atualiza Equipamento
                    equip.actualize_Equip = value;

                    //Atualiza visual do equipamento
                    actualize_UI();

                    //Atualiza tela de controle e status do equipamento

                }

            }
            get { return true; }        

        }

    }
}
