using DiamondKata.Common.Models;

namespace DiamondKata.Infrastructure.Services;

public interface IInputHandler
{
    Result<char> GetInput();
    bool ShouldQuit(char input);
} 