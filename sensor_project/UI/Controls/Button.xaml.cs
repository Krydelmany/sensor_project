using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

/*
 * Define um controle personalizado chamado Button que herda de UserControl no namespace sensor_project.UI.Controls. 
 * Ele inclui várias propriedades dependentes (Dependency Properties) que permitem a personalização do controle através de XAML
 */

namespace sensor_project.UI.Controls
{
    public partial class Button : UserControl
    {
        public Button()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Button), new PropertyMetadata(string.Empty));

        public string BackgroundColor
        {
            get { return (string)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register("BackgroundColor", typeof(string), typeof(Button), new PropertyMetadata("White"));

        public string ForegroundColor
        {
            get { return (string)GetValue(ForegroundColorProperty); }
            set { SetValue(ForegroundColorProperty, value); }
        }

        public static readonly DependencyProperty ForegroundColorProperty =
            DependencyProperty.Register("ForegroundColor", typeof(string), typeof(Button), new PropertyMetadata("Black"));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(Button), new PropertyMetadata(null));

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static new readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register("IsEnabled", typeof(bool), typeof(Button), new PropertyMetadata(true));

    }
}
