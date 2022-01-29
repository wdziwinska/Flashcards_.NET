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
        public int clickFirstLangugeCount = 1;
        public int clickSecondLangugeCount = 1;
        String nameCheckBox;
        String nameCheckBoxSecondLanguage;

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
                fPolish.IsHitTestVisible = false;
            }

            else if ((bool)fEnglish.IsChecked)
            {
                firstLanguageId = 2;
                fEnglish.IsHitTestVisible = false;
            }

            else if ((bool)fGerman.IsChecked)
            {
                firstLanguageId = 3;
                fGerman.IsHitTestVisible = false;
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
        private void CheckBoxFirstLanguage_Click(object sender, RoutedEventArgs e)
        {
            if(nameCheckBox == "fPolish") {fPolish.IsChecked = false;}
            else if(nameCheckBox == "fEnglish") {fEnglish.IsChecked = false;}
            else if(nameCheckBox == "fGerman") { fGerman.IsChecked = false;}
            else if(nameCheckBox == "fRussian") {fRussian.IsChecked = false;}
            else if(nameCheckBox == "fItalian") {fItalian.IsChecked = false;}
            else if(nameCheckBox == "fFrench") {fFrench.IsChecked = false;}

            if ((bool)fPolish.IsChecked)
            {
                fEnglish.IsChecked = false;
                fGerman.IsChecked = false;
                fRussian.IsChecked = false;
                fItalian.IsChecked = false;
                fFrench.IsChecked = false;
                nameCheckBox = "fPolish";
            }

            else if ((bool)fEnglish.IsChecked)
            {
                fPolish.IsChecked = false;
                fGerman.IsChecked = false;
                fRussian.IsChecked = false;
                fItalian.IsChecked = false;
                fFrench.IsChecked = false;
                nameCheckBox = "fEnglish";
            }
            else if ((bool)fGerman.IsChecked)
            {
                fPolish.IsChecked = false;
                fEnglish.IsChecked = false;
                fRussian.IsChecked = false;
                fItalian.IsChecked = false;
                fFrench.IsChecked = false;
                nameCheckBox = "fGerman";
            }
            else if ((bool)fRussian.IsChecked)
            {
                fPolish.IsChecked = false;
                fEnglish.IsChecked = false;
                fGerman.IsChecked = false;
                fItalian.IsChecked = false;
                fFrench.IsChecked = false;
                nameCheckBox = "fRussian";
            }

            else if ((bool)fItalian.IsChecked)
            {
                fPolish.IsChecked = false;
                fEnglish.IsChecked = false;
                fGerman.IsChecked = false;
                fRussian.IsChecked = false;
                fFrench.IsChecked = false;
                nameCheckBox = "fItalian";
            }

            else if ((bool)fFrench.IsChecked)
            {
                fPolish.IsChecked = false; 
                fEnglish.IsChecked = false;
                fGerman.IsChecked = false;
                fRussian.IsChecked = false;
                fItalian.IsChecked = false;
                nameCheckBox = "fFrench";
            }
        }

        private void CheckBoxSecondLanguage_Click(object sender, RoutedEventArgs e)
        {
            if (nameCheckBoxSecondLanguage == "sPolish") { sPolish.IsChecked = false; }
            else if (nameCheckBoxSecondLanguage == "sEnglish") { sEnglish.IsChecked = false; }
            else if (nameCheckBoxSecondLanguage == "sGerman") { sGerman.IsChecked = false; }
            else if (nameCheckBoxSecondLanguage == "sRussian") { sRussian.IsChecked = false; }
            else if (nameCheckBoxSecondLanguage == "sItalian") { sItalian.IsChecked = false; }
            else if (nameCheckBoxSecondLanguage == "sFrench") { sFrench.IsChecked = false; }

            if ((bool)sPolish.IsChecked)
            {
                sEnglish.IsChecked = false;
                sGerman.IsChecked = false;
                sRussian.IsChecked = false;
                sItalian.IsChecked = false;
                sFrench.IsChecked = false;
                nameCheckBoxSecondLanguage = "sPolish";
            }

            else if ((bool)sEnglish.IsChecked)
            {
                sPolish.IsChecked = false;
                sGerman.IsChecked = false;
                sRussian.IsChecked = false;
                sItalian.IsChecked = false;
                sFrench.IsChecked = false;
                nameCheckBoxSecondLanguage = "sEnglish";
            }
            else if ((bool)sGerman.IsChecked)
            {
                sPolish.IsChecked = false;
                sEnglish.IsChecked = false;
                sRussian.IsChecked = false;
                sItalian.IsChecked = false;
                sFrench.IsChecked = false;
                nameCheckBoxSecondLanguage = "sGerman";
            }
            else if ((bool)sRussian.IsChecked)
            {
                sPolish.IsChecked = false;
                sEnglish.IsChecked = false;
                sGerman.IsChecked = false;
                sItalian.IsChecked = false;
                sFrench.IsChecked = false;
                nameCheckBoxSecondLanguage = "sRussian";
            }

            else if ((bool)sItalian.IsChecked)
            {
                sPolish.IsChecked = false;
                sEnglish.IsChecked = false;
                sGerman.IsChecked = false;
                sRussian.IsChecked = false;
                sFrench.IsChecked = false;
                nameCheckBoxSecondLanguage = "sItalian";
            }

            else if ((bool)sFrench.IsChecked)
            {
                sPolish.IsChecked = false;
                sEnglish.IsChecked = false;
                sGerman.IsChecked = false;
                sRussian.IsChecked = false;
                sItalian.IsChecked = false;
                nameCheckBoxSecondLanguage = "sFrench";
            }
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
