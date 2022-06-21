namespace Becerra.Deck
{
    using UnityEngine;
    using Sirenix.OdinInspector;
    using Unity.VisualScripting;

    [System.Serializable]
    [Inspectable]
    [CreateAssetMenu(fileName = "Card", menuName = "Becerra/Data/Card")]
    public class CardData : ScriptableObject
    {
        [SerializeField, EnumToggleButtons] private CardType type;
        [SerializeField, SuffixLabel("s", true)] private int buildDuration;
        [SerializeField, TableList] private CardCost[] costs;
        [SerializeField, InlineEditor(InlineEditorModes.LargePreview), AssetList(Path = "Art/Sprites/Cards/Splash")] private Sprite splashImage;

        public string ID => this.name;

        public CardType CardType => this.type;

        public int BuildDuration => buildDuration;

        public int CostsCount => this.costs.Length;

        public string NameKey => $"{this.ID}_NAME";

        public string DescriptionKey => $"{this.ID}_DESCRIPTION";

        public Sprite SplashImage => this.splashImage;

        public CardCost GetCost(int index) => this.costs[index];

        public Sprite GetSplashImage() => this.splashImage;
    }
}