using Zenject;

public class Installer : MonoInstaller
{
    public DragArea DragArea;

    public PlayerTrigger PlayerTrigger;

    public override void InstallBindings()
    {
        Container.Bind<DragArea>().FromInstance(DragArea).AsSingle().NonLazy();

        Container.Bind<PlayerTrigger>().FromInstance(PlayerTrigger).AsSingle().NonLazy();
    }
}