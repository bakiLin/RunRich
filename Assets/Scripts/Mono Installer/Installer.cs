using Zenject;

public class Installer : MonoInstaller
{
    public DragArea DragArea;

    public override void InstallBindings()
    {
        Container.Bind<DragArea>().FromInstance(DragArea).AsSingle().NonLazy();
    }
}