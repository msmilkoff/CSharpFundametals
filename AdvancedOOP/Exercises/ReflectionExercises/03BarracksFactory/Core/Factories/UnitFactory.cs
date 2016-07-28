namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            string currentNamespace = "_03BarracksFactory.Models.Units.";
            var typeOfUnit = Type.GetType(currentNamespace + unitType);
            var unit = Activator.CreateInstance(typeOfUnit);

            return unit as IUnit;
        }
    }
}
