using System;
using System.Collections.Generic;
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
using System.Runtime.InteropServices;

namespace Fiszki_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Engine engine = new Engine();
        bool translated = false;
        public MainWindow()
        {
            InitializeComponent();
            test.Visibility = Visibility.Collapsed;
            Phrase.Text = engine.setCurrentWordinFirstLanguage();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void pokaz_tlumaczenie_Click(object sender, RoutedEventArgs e)
        {
            if (translated)
            {
                Phrase.Text = engine.getCurrentWordinFirstLanguage();
                translated = false;
            }
            else
            {
                Phrase.Text = engine.getCurrentWordInSecondLanguage();
                translated = true;
            }
            
        }

        private void Znam_Click(object sender, RoutedEventArgs e)
        {
            translated = false;
            if (engine.phrases.Count > 0)
            {
                engine.phrases.RemoveAt(0);
            }
            
            Phrase.Text = engine.setCurrentWordinFirstLanguage();
        }

        private void nie_umiem_Click(object sender, RoutedEventArgs e)
        {
            translated = false;
            if (engine.phrases.Count > 0)
            {
                engine.phrases.RemoveAt(0);
            }
            Phrase.Text = engine.setCurrentWordinFirstLanguage();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility=Visibility.Collapsed;
            test.Visibility = Visibility.Visible;
        }
      

        private void Wroc_Click(object sender, RoutedEventArgs e)
        {
            test.Visibility = Visibility.Collapsed;
            menu.Visibility = Visibility.Visible;
        }

    }
}
