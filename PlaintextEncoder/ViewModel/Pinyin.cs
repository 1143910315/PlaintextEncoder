namespace PlaintextEncoder.ViewModel {
    internal class Pinyin : ViewModelBase {
        private string _value;
        public string Value {
            get => _value;
            set => Set(ref _value, value);
        }
        public Pinyin(string value) {
            _value = value;
        }
    }
}
