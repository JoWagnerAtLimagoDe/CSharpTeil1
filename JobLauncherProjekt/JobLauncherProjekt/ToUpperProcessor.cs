using RicisBatch.Step.ChunkStep;

namespace JobLauncherProjekt
{

    public class ToUpperProcessor : AbstractProcessor<string, string>
    {


        public override string Process(string item)
        {

            return item.ToUpper();
        }
    }
}
