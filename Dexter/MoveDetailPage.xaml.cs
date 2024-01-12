namespace Dexter;

public partial class MoveDetailPage : ContentPage
{
    private CollectionView _moveCollectionView;
    public MoveDetailPage(PokemonMoves selectedMove, CollectionView collectionView)
	{
		InitializeComponent();
        BindingContext = selectedMove;
        _moveCollectionView = collectionView;
        Title = selectedMove.MoveName;
    }
}