using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;
using System.Collections.Generic;

namespace DB_LR_7_8
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Переменная, предназначенная для соединения с БД, разработанной в предыдущих ЛР
        /// </summary>
        private OleDbConnection connection = null;
        /// <summary>
        /// Переменная, предназначенная для хранения данных, выгруженных из БД
        /// </summary>
        private DataSet dataSet;
        /// <summary>
        /// Переменная, предназначенная для извлечения данных из БД в датасет
        /// </summary>
        private OleDbDataAdapter dataAdapter;
        /// <summary>
        /// Переменная, предназначенная для автоматической генерации операций над датасетом
        /// </summary>
        private OleDbCommandBuilder commandBuilder;
        /// <summary>
        /// Множество выборочных запросов, которые надо выгрузить из БД
        /// </summary>
        private HashSet<string> queriesSet = new HashSet<string>(
            new string[] { "_select1", "_select2", "_select3", "_where1", "_where2", "_where4" });
        /// <summary>
        /// Множество запросов на изменение данных, которые надо выгрузить из БД
        /// </summary>
        private HashSet<string> proceduresSet = new HashSet<string>(
            new string[] { "6_insertAutobus", "6_deleteAutobus", "6_update1"});
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод, вызываемый при загрузке Form1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onForm1Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(
                ConfigurationManager.ConnectionStrings["DataBase_LR"].ConnectionString);

            connection.Open();

            Console.WriteLine(connection.State == ConnectionState.Open ?
                "Подключение установлено" : "Не удалось установить подключение");

            FillTableList();
            FillQueriesList();
        }
        /// <summary>
        /// Метод, отвечающий за отображение выбранной таблицы на экране
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectTableFromTableList(object sender, EventArgs e)
        {
            try
            {
                string selectedTable = tableList.SelectedItem.ToString();
                string query = $"SELECT * FROM {selectedTable}";
                OleDbCommand command = new OleDbCommand(query, connection);

                dataAdapter = new OleDbDataAdapter(command);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet);

                dataGrid.DataSource = dataSet.Tables[0];

                commandBuilder = new OleDbCommandBuilder(dataAdapter);
                dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
                dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Заполнить список таблиц
        /// </summary>
        private void FillTableList()
        {
            try
            {
                DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, 
                    new object[] { null, null, null, "TABLE" });
                foreach (DataRow row in schemaTable.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    tableList.Items.Add(tableName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading table names: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Метод отвечающий за сохранение внесённых изменений по нажатию кнопки saveButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onSaveChangesClick(object sender, EventArgs e)
        {
            try
            {
                if (dataAdapter is null || dataSet is null) throw new Exception("No loaded table to save");

                dataAdapter.Update(dataSet.Tables[0]);

                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Метод, отвечающий за удаление строчки из таблицы по нажатию кнопки deleteButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onDeleteClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid.SelectedRows.Count > 0)
                {
                    int selectedIndex = dataGrid.SelectedRows[0].Index;
                    dataGrid.Rows.RemoveAt(selectedIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting data: " + ex.Message, "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Метод, отвечающий за выполнение запроса находящегося в queryList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectQueryFromQueriesList(object sender, EventArgs e)
        {
            try
            {
                string selected = queryList.SelectedItem.ToString();

                if( queriesSet.Contains(selected))
                {
                    string query = $"SELECT * FROM {selected}";
                    OleDbCommand command = new OleDbCommand(query, connection);

                    dataAdapter = new OleDbDataAdapter(command);
                    dataSet = new DataSet();

                    dataAdapter.Fill(dataSet);

                    dataGrid.DataSource = dataSet.Tables[0];
                }
                else if (proceduresSet.Contains(selected))
                {
                    try
                    {
                        OleDbCommand command = new OleDbCommand(selected, connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        MessageBox.Show("Procedure executed successfully.", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error executing procedure: " + ex.Message, "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                /*commandBuilder = new OleDbCommandBuilder(dataAdapter);
                dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
                dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Заполнить список запросов
        /// </summary>
        private void FillQueriesList()
        {
            try
            {
                DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "VIEW" });
                foreach (DataRow row in schemaTable.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    if(queriesSet.Contains(tableName))
                        queryList.Items.Add(tableName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading table names: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Procedures,
                    new object[] { null, null, null, null });

                foreach (DataRow row in schemaTable.Rows)
                {
                    string procedureName = row["PROCEDURE_NAME"].ToString();
                    if(proceduresSet.Contains(procedureName))
                        queryList.Items.Add(procedureName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stored procedure names: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
