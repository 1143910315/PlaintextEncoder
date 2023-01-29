using ToolGood.Words.Pinyin;

namespace PlaintextEncoder;

public partial class MainPage : ContentPage {
    int count = 0;

    public MainPage() {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e) {
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
        } else {
            OutputText.Text = "";
        }
    }
}

