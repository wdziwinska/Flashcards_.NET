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
    /// 
    // 1 - Polski
    // 2 - Angielski
    // 3 - Niemiecki
    // 4 - Rosyjski
    // 5 - Wloski
    // 6 - Francuski
    public partial class MainWindow : Window
    {

        bool translated = false;
        private static int firstLanguageId;
        private static int secondLanguageId;
        Engine engine = new Engine();

        //Console.WriteLine("firstLanguageId", firstLanguageId);


        public MainWindow()
        {
            InitializeComponent();
            test.Visibility = Visibility.Collapsed;
            languages.Visibility = Visibility.Collapsed;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            languages.Visibility = Visibility.Collapsed;
            test.Visibility = Visibility.Visible;

            if ((bool)fPolish.IsChecked)
            {
                firstLanguageId = 1;
            }

            else if ((bool)fEnglish.IsChecked)
            {
                firstLanguageId = 2;
            }

            else if ((bool)fGerman.IsChecked)
            {
                firstLanguageId = 3;
            }

            if ((bool)fRussian.IsChecked)
            {
                firstLanguageId = 4;
            }

            else if ((bool)fItalian.IsChecked)
            {
                firstLanguageId = 5;
            }

            else if ((bool)fFrench.IsChecked)
            {
                firstLanguageId = 6;
            }

            if ((bool)sPolish.IsChecked)
            {
                secondLanguageId = 1;
            }

            else if ((bool)sEnglish.IsChecked)
            {
                secondLanguageId = 2;
            }

            else if ((bool)sGerman.IsChecked)
            {
                secondLanguageId = 3;
            }

            if ((bool)sRussian.IsChecked)
            {
                secondLanguageId = 4;
            }

            else if ((bool)sItalian.IsChecked)
            {
                secondLanguageId = 5;
            }

            else if ((bool)sFrench.IsChecked)
            {
                secondLanguageId = 6;
            }
            engine.setLanguagesForLeaning(firstLanguageId, secondLanguageId);
            Phrase.Text = engine.setCurrentWordinFirstLanguage();

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

            engine.storeKnownWord();
            if (engine.phrases.Count > 0)
            {
                engine.phrases.RemoveAt(0);
            }
            
            Phrase.Text = engine.setCurrentWordinFirstLanguage();
        }

        private void nie_umiem_Click(object sender, RoutedEventArgs e)
        {
            translated = false;

            engine.storeUnknownWord();
            if (engine.phrases.Count > 0)
            {
                engine.phrases.RemoveAt(0);
            }
            Phrase.Text = engine.setCurrentWordinFirstLanguage();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility=Visibility.Collapsed;
            languages.Visibility = Visibility.Visible;

            fPolish.IsChecked = false;
            fEnglish.IsChecked = false;
            fGerman.IsChecked = false;
            fRussian.IsChecked = false;
            fItalian.IsChecked = false;
            fFrench.IsChecked = false;
            sPolish.IsChecked = false;
            sEnglish.IsChecked = false;
            sGerman.IsChecked = false;
            sRussian.IsChecked = false;
            sItalian.IsChecked = false;
            sFrench.IsChecked = false;
        }


        private void Wroc_Click(object sender, RoutedEventArgs e)
        {
            test.Visibility = Visibility.Collapsed;
            menu.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        /*        private void Submit_Click(object sender, RoutedEventArgs e)
                {
                    firstlanguage.Visibility = Visibility.Collapsed;
                    test.Visibility = Visibility.Visible;
                }*/

    }
}
