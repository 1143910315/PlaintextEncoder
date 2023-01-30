using PlaintextEncoder.ViewModel;
using System.Collections.ObjectModel;
using ToolGood.Words.Pinyin;

namespace PlaintextEncoder;

public partial class MainPage : ContentPage {
    int count = 0;

    public MainPage() {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e) {
        if (PinyinView.ItemsSource is ObservableCollection<Pinyin> pinyinList) {
            if (PinyinEncodeView.ItemsSource is ObservableCollection<Pinyin> pinyinEncodeList) {
                pinyinList.Clear();
                pinyinEncodeList.Clear();
                List<string> list = WordsHelper.GetAllPinyin('我', true);
                for (int i = 0; i < list.Count; i++) {
                    pinyinList.Add(new Pinyin(list[i].ToLower()));
                    pinyinEncodeList.Add(new Pinyin(PinyinEncode(list[i].ToLower())));
                }
            }
        }
        count++;

        if (count == 1) {
            CounterBtn.Text = $"Clicked {count} time";
        } else {
            CounterBtn.Text = $"Clicked {count} times";
        }
        string[] strings = WordsHelper.GetPinyinList("一骑绝尘", true);
        for (int i = 0; i < strings.Length; i++) {
            CounterBtn.Text += strings[i] + "-";
        }
        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void InputText_TextChanged(object sender, TextChangedEventArgs e) {
        if (e.NewTextValue.Length > 0) {
            OutputText.Text = WordsHelper.GetPinyin(e.NewTextValue, true);
            if (PinyinView.ItemsSource is ObservableCollection<Pinyin> pinyinList) {
                if (PinyinEncodeView.ItemsSource is ObservableCollection<Pinyin> pinyinEncodeList) {
                    pinyinList.Clear();
                    pinyinEncodeList.Clear();
                    List<string> list = WordsHelper.GetAllPinyin(e.NewTextValue[0], true);
                    for (int i = 0; i < list.Count; i++) {
                        pinyinList.Add(new Pinyin(list[i].ToLower()));
                        pinyinEncodeList.Add(new Pinyin(PinyinEncode(list[i].ToLower())));
                    }
                }

            }
        } else {
            OutputText.Text = "";
        }
    }

    private static string PinyinEncode(string pinyinWithTone) {
        int tone = 0;
        char[] one = { 'ā', 'ē', 'ī', 'ō', 'ū' };
        char[] two = { 'á', 'é', 'í', 'ó', 'ú' };
        char[] three = { 'ǎ', 'ě', 'ǐ', 'ǒ', 'ǔ' };
        char[] four = { 'à', 'è', 'ì', 'ò', 'ù' };
        if (pinyinWithTone.IndexOfAny(one) >= 0) {
            tone = 1;
        }
        if (pinyinWithTone.IndexOfAny(two) >= 0) {
            tone = 2;
        }
        if (pinyinWithTone.IndexOfAny(three) >= 0) {
            tone = 3;
        }
        if (pinyinWithTone.IndexOfAny(four) >= 0) {
            tone = 4;
        }
        return pinyinWithTone
            .Replace("a", "11").Replace("ā", "11").Replace("á", "11").Replace("ǎ", "11").Replace("à", "11")
            .Replace("b", "12")
            .Replace("c", "13")
            .Replace("d", "14")
            .Replace("e", "15").Replace("ē", "15").Replace("é", "15").Replace("ě", "15").Replace("è", "15")
            .Replace("f", "16")
            .Replace("g", "17")
            .Replace("h", "21")
            .Replace("i", "22").Replace("ī", "22").Replace("í", "22").Replace("ǐ", "22").Replace("ì", "22")
            .Replace("j", "23")
            .Replace("k", "24")
            .Replace("l", "25")
            .Replace("m", "26")
            .Replace("n", "27")
            .Replace("o", "31").Replace("ō", "31").Replace("ó", "31").Replace("ǒ", "31").Replace("ò", "31")
            .Replace("p", "32")
            .Replace("q", "33")
            .Replace("r", "34")
            .Replace("s", "35")
            .Replace("t", "36")
            .Replace("u", "41").Replace("ū", "41").Replace("ú", "41").Replace("ǔ", "41").Replace("ù", "41")
            .Replace("v", "42")
            .Replace("w", "43")
            .Replace("x", "44")
            .Replace("y", "45")
            .Replace("z", "46") + "0" + tone;
    }
}

