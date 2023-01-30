using System.Collections.ObjectModel;

namespace PlaintextEncoder.ViewModel {
    internal class PinyinViewModel : ViewModelBase {

        private ObservableCollection<Pinyin> _allPinyin = new();

        public ObservableCollection<Pinyin> AllPinyin {
            get {
                return _allPinyin;
            }

            set {
                Set(ref _allPinyin, value);
            }
        }
    }
}