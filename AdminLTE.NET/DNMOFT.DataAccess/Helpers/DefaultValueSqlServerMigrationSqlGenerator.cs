// ***********************************************************************
// Assembly         : DNMOFT.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="DefaultValueSqlServerMigrationSqlGenerator.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.DataAccess.Helpers
{
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.SqlServer;

    /// <summary>
    /// Class DefaultValueSqlServerMigrationSqlGenerator.
    /// Implements the <see cref="System.Data.Entity.SqlServer.SqlServerMigrationSqlGenerator" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.SqlServer.SqlServerMigrationSqlGenerator" />
    internal class DefaultValueSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        #region Fields

        /// <summary>
        /// The drop constraint count
        /// </summary>
        private int _dropConstraintCount;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.AddColumnOperation" />.
        /// Generated SQL should be added using the Statement method.
        /// </summary>
        /// <param name="addColumnOperation">The operation to produce SQL for.</param>
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetAnnotatedColumn(addColumnOperation.Column, addColumnOperation.Table);
            base.Generate(addColumnOperation);
        }

        /// <summary>
        /// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.AlterColumnOperation" />.
        /// Generated SQL should be added using the Statement method.
        /// </summary>
        /// <param name="alterColumnOperation">The operation to produce SQL for.</param>
        protected override void Generate(AlterColumnOperation alterColumnOperation)
        {
            SetAnnotatedColumn(alterColumnOperation.Column, alterColumnOperation.Table);
            base.Generate(alterColumnOperation);
        }

        /// <summary>
        /// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.CreateTableOperation" />. This method differs from
        /// <see cref="M:System.Data.Entity.SqlServer.SqlServerMigrationSqlGenerator.WriteCreateTable(System.Data.Entity.Migrations.Model.CreateTableOperation)" /> in that it will
        /// create the target database schema if it does not already exist.
        /// Generated SQL should be added using the Statement method.
        /// </summary>
        /// <param name="createTableOperation">The operation to produce SQL for.</param>
        protected override void Generate(CreateTableOperation createTableOperation)
        {
            SetAnnotatedColumns(createTableOperation.Columns, createTableOperation.Name);
            base.Generate(createTableOperation);
        }

        /// <summary>
        /// Override this method to generate SQL when the definition of a table or its attributes are changed.
        /// The default implementation of this method does nothing.
        /// </summary>
        /// <param name="alterTableOperation">The operation describing changes to the table.</param>
        protected override void Generate(AlterTableOperation alterTableOperation)
        {
            SetAnnotatedColumns(alterTableOperation.Columns, alterTableOperation.Name);
            base.Generate(alterTableOperation);
        }

        /// <summary>
        /// Gets the SQL drop constraint query.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        private string GetSqlDropConstraintQuery(string tableName, string columnName)
        {
            var str = $@"DECLARE @var{_dropConstraintCount} nvarchar(128)
            SELECT @var{_dropConstraintCount} = name
            FROM sys.default_constraints
            WHERE parent_object_id = object_id(N'{tableName}')
            AND col_name(parent_object_id, parent_column_id) = '{columnName}';
            IF @var{_dropConstraintCount} IS NOT NULL
            EXECUTE('ALTER TABLE {tableName} DROP CONSTRAINT [' + @var{_dropConstraintCount} + ']')";

            _dropConstraintCount++;
            return str;
        }

        /// <summary>
        /// Sets the annotated column.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="tableName">Name of the table.</param>
        private void SetAnnotatedColumn(ColumnModel column, string tableName)
        {
            if (!column.Annotations.TryGetValue("SqlDefaultValue", out AnnotationValues values))
            {
                return;
            }

            if (values.NewValue == null)
            {
                column.DefaultValueSql = null;
                using (var writer = Writer())
                {
                    // Drop Constraint
                    writer.WriteLine(GetSqlDropConstraintQuery(tableName, column.Name));
                    Statement(writer);
                }
            }
            else
            {
                column.DefaultValueSql = (string)values.NewValue;
            }
        }

        /// <summary>
        /// Sets the annotated columns.
        /// </summary>
        /// <param name="columns">The columns.</param>
        /// <param name="tableName">Name of the table.</param>
        private void SetAnnotatedColumns(IEnumerable<ColumnModel> columns, string tableName)
        {
            foreach (var column in columns)
            {
                SetAnnotatedColumn(column, tableName);
            }
        }

        #endregion Methods
    }
}