// SimpleMediator/Unit.cs
namespace MediatR
{
    // Представляет void.
    public readonly struct Unit
    {
        public static readonly Unit Value = new();
    }
}