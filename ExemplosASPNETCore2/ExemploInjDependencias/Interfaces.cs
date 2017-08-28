using System;

namespace ExemploInjDependencias
{
    public interface ITesteA
    {
        Guid IdReferencia { get; }
    }

    public interface ITesteB
    {
        Guid IdReferencia { get; }
    }
}