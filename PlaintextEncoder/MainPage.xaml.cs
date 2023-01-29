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

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void InputText_TextChanged(object sender, TextChangedEventArgs e) {
        if (e.NewTextValue.Length > 0) {
            OutputText.Text = WordsHelper.GetPinyinForName(e.NewTextValue, true);
        } else {
            OutputText.Text = "";
        }
    }
}

