// <auto-generated />
using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace EFCore6Sample.CompiledModels
{
    internal partial class BankAccountEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "BankAccount",
                typeof(BankAccount),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(BankAccount).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(BankAccount).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            var balance = runtimeEntityType.AddProperty(
                "Balance",
                typeof(decimal),
                propertyInfo: typeof(BankAccount).GetProperty("Balance", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(BankAccount).GetField("<Balance>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                precision: 10,
                scale: 1);
            balance.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var periodEnd = runtimeEntityType.AddProperty(
                "PeriodEnd",
                typeof(DateTime),
                valueGenerated: ValueGenerated.OnAddOrUpdate,
                beforeSaveBehavior: PropertySaveBehavior.Ignore,
                afterSaveBehavior: PropertySaveBehavior.Ignore);
            periodEnd.AddAnnotation("Relational:ColumnName", "PeriodEnd");
            periodEnd.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var periodStart = runtimeEntityType.AddProperty(
                "PeriodStart",
                typeof(DateTime),
                valueGenerated: ValueGenerated.OnAddOrUpdate,
                beforeSaveBehavior: PropertySaveBehavior.Ignore,
                afterSaveBehavior: PropertySaveBehavior.Ignore);
            periodStart.AddAnnotation("Relational:ColumnName", "PeriodStart");
            periodStart.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "BankAccounts");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);
            runtimeEntityType.AddAnnotation("SqlServer:IsTemporal", true);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
