using _08.MilitaryElite.Enums;

namespace _08.MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }
        void CompleteMission();
    }
}
