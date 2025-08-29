using Zenject;

public class Installer : MonoInstaller
{
    public DragArea DragArea;

    public PlayerTrigger PlayerTrigger;

    public MoneyBar MoneyBar;

    public override void InstallBindings()
    {
        Container.Bind<DragArea>().FromInstance(DragArea).AsSingle().NonLazy();

        Container.Bind<PlayerTrigger>().FromInstance(PlayerTrigger).AsSingle().NonLazy();

        Container.Bind<MoneyBar>().FromInstance(MoneyBar).AsSingle().NonLazy();
    }
}