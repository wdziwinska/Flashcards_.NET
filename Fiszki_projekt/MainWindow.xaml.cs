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
using System.Diagnostics;

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
        String nameCheckBox;
        String nameCheckBoxSecondLanguage;
        String nameCheckBoxWayToLearn;

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

            if ((bool)fPolish.IsChecked) { firstLanguageId = 1; }
            else if ((bool)fEnglish.IsChecked) { firstLanguageId = 2; }
            else if ((bool)fGerman.IsChecked) { firstLanguageId = 3; }
            else if ((bool)fRussian.IsChecked) { firstLanguageId = 4; }
            else if ((bool)fItalian.IsChecked) { firstLanguageId = 5; }
            else if ((bool)fFrench.IsChecked) { firstLanguageId = 6; }
            if ((bool)sPolish.IsChecked) { secondLanguageId = 1; }
            else if ((bool)sEnglish.IsChecked) { secondLanguageId = 2; }
            else if ((bool)sGerman.IsChecked) { secondLanguageId = 3; }
            else if ((bool)sRussian.IsChecked) { secondLanguageId = 4; }
            else if ((bool)sItalian.IsChecked) { secondLanguageId = 5; } 
            else if ((bool)sFrench.IsChecked) { secondLanguageId = 6; }

            engine.firstLanguageId = firstLanguageId;
            engine.secondLanguageId = secondLanguageId;

            ComboBoxItem typeItem = (ComboBoxItem)comboBox.SelectedItem;
            string value = typeItem.Content.ToString();
            int numberOfWordtolearn = Convert.ToInt32(value);
            Debug.WriteLine("value: ", value);


            if ((bool)repetitions.IsChecked)
            {
                engine.wordsForRepetitions(firstLanguageId, secondLanguageId, numberOfWordtolearn);
            }
            else if ((bool)newPhrases.IsChecked)
            {
                engine.setLanguagesForLeaning(firstLanguageId, secondLanguageId, numberOfWordtolearn);
            }
            engine.removeKnownWordsFromPhrases(numberOfWordtolearn);
            Phrase.Text = engine.setCurrentWordinFirstLanguage();
            
        }
        private void CheckBoxFirstLanguage_Click(object sender, RoutedEventArgs e)
        {
            if(nameCheckBox == "fPolish") {fPolish.IsChecked = false; sPolish.IsHitTestVisible = true; }
            else if(nameCheckBox == "fEnglish") {fEnglish.IsChecked = false; sEnglish.IsHitTestVisible = true; }
            else if(nameCheckBox == "fGerman") { fGerman.IsChecked = false; sGerman.IsHitTestVisible = true; }
            else if(nameCheckBox == "fRussian") {fRussian.IsChecked = false; sRussian.IsHitTestVisible = true; }
            else if(nameCheckBox == "fItalian") {fItalian.IsChecked = false; sItalian.IsHitTestVisible = true; }
            else if(nameCheckBox == "fFrench") {fFrench.IsChecked = false; sFrench.IsHitTestVisible = true; }

            if ((bool)fPolish.IsChecked)
            {
                sPolish.IsHitTestVisible = false;
                fEnglish.IsChecked = false;
                fGerman.IsChecked = false;
                fRussian.IsChecked = false;
                fItalian.IsChecked = false;
                fFrench.IsChecked = false;
                nameCheckBox = "fPolish";
            }

            else if ((bool)fEnglish.IsChecked)
            {
                sEnglish.IsHitTestVisible = false;
                fPolish.IsChecked = false;
                fGerman.IsChecked = false;
                fRussian.IsChecked = false;
                fItalian.IsChecked = false;
                fFrench.IsChecked = false;
                nameCheckBox = "fEnglish";
            }
            else if ((bool)fGerman.IsChecked)
            {
                sGerman.IsHitTestVisible = false;
                fPolish.IsChecked = false;
                fEnglish.IsChecked = false;
                fRussian.IsChecked = false;
                fItalian.IsChecked = false;
                fFrench.IsChecked = false;
                nameCheckBox = "fGerman";
            }
            else if ((bool)fRussian.IsChecked)
            {
                sRussian.IsHitTestVisible = false;
                fPolish.IsChecked = false;
                fEnglish.IsChecked = false;
                fGerman.IsChecked = false;
                fItalian.IsChecked = false;
                fFrench.IsChecked = false;
                nameCheckBox = "fRussian";
            }

            else if ((bool)fItalian.IsChecked)
            {
                sItalian.IsHitTestVisible = false;
                fPolish.IsChecked = false;
                fEnglish.IsChecked = false;
                fGerman.IsChecked = false;
                fRussian.IsChecked = false;
                fFrench.IsChecked = false;
                nameCheckBox = "fItalian";
            }

            else if ((bool)fFrench.IsChecked)
            {
                sFrench.IsHitTestVisible = false;
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
            if (nameCheckBoxSecondLanguage == "sPolish") { sPolish.IsChecked = false; fPolish.IsHitTestVisible = true; }
            else if (nameCheckBoxSecondLanguage == "sEnglish") { sEnglish.IsChecked = false; fEnglish.IsHitTestVisible = true; }
            else if (nameCheckBoxSecondLanguage == "sGerman") { sGerman.IsChecked = false; fGerman.IsHitTestVisible = true; }
            else if (nameCheckBoxSecondLanguage == "sRussian") { sRussian.IsChecked = false; fRussian.IsHitTestVisible = true; }
            else if (nameCheckBoxSecondLanguage == "sItalian") { sItalian.IsChecked = false; fItalian.IsHitTestVisible = true; }
            else if (nameCheckBoxSecondLanguage == "sFrench") { sFrench.IsChecked = false; fFrench.IsHitTestVisible = true; }

            if ((bool)sPolish.IsChecked)
            {
                fPolish.IsHitTestVisible = false;
                sEnglish.IsChecked = false;
                sGerman.IsChecked = false;
                sRussian.IsChecked = false;
                sItalian.IsChecked = false;
                sFrench.IsChecked = false;
                nameCheckBoxSecondLanguage = "sPolish";
            }

            else if ((bool)sEnglish.IsChecked)
            {
                fEnglish.IsHitTestVisible = false;
                sPolish.IsChecked = false;
                sGerman.IsChecked = false;
                sRussian.IsChecked = false;
                sItalian.IsChecked = false;
                sFrench.IsChecked = false;
                nameCheckBoxSecondLanguage = "sEnglish";
            }
            else if ((bool)sGerman.IsChecked)
            {
                fGerman.IsHitTestVisible = false;
                sPolish.IsChecked = false;
                sEnglish.IsChecked = false;
                sRussian.IsChecked = false;
                sItalian.IsChecked = false;
                sFrench.IsChecked = false;
                nameCheckBoxSecondLanguage = "sGerman";
            }
            else if ((bool)sRussian.IsChecked)
            {
                fRussian.IsHitTestVisible = false;
                sPolish.IsChecked = false;
                sEnglish.IsChecked = false;
                sGerman.IsChecked = false;
                sItalian.IsChecked = false;
                sFrench.IsChecked = false;
                nameCheckBoxSecondLanguage = "sRussian";
            }

            else if ((bool)sItalian.IsChecked)
            {
                fItalian.IsHitTestVisible = false;
                sPolish.IsChecked = false;
                sEnglish.IsChecked = false;
                sGerman.IsChecked = false;
                sRussian.IsChecked = false;
                sFrench.IsChecked = false;
                nameCheckBoxSecondLanguage = "sItalian";
            }

            else if ((bool)sFrench.IsChecked)
            {
                fFrench.IsHitTestVisible = false;
                sPolish.IsChecked = false;
                sEnglish.IsChecked = false;
                sGerman.IsChecked = false;
                sRussian.IsChecked = false;
                sItalian.IsChecked = false;
                nameCheckBoxSecondLanguage = "sFrench";
            }
        }

        private void CheckBoxWayToLearn_Click(object sender, RoutedEventArgs e)
        {
            if (nameCheckBoxWayToLearn == "repetitions") { repetitions.IsChecked = false; }
            else if (nameCheckBoxWayToLearn == "newPhrases") { newPhrases.IsChecked = false; }

            if ((bool)repetitions.IsChecked)
            {
                newPhrases.IsChecked = false;
                nameCheckBoxWayToLearn = "repetitions";
            }
            else if((bool)newPhrases.IsChecked)
            {
                repetitions.IsChecked = false;
                nameCheckBoxWayToLearn = "newPhrases";
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

/*            fPolish.IsChecked = false;
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
            sFrench.IsChecked = false;*/
        }


        private void Wroc_Click(object sender, RoutedEventArgs e)
        {
            test.Visibility = Visibility.Collapsed;
            menu.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
