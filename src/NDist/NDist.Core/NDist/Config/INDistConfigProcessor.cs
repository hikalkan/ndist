namespace Hik.NDist.Config
{
    public interface INDistConfigProcessor
    {
        NDistConfig Load();

        void Save(NDistConfig config);
    }
}