using CVirtual.Presenter;
using CVirtual.Utils.ExtensionMethods;
using CVirtual.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVirtual.Views
{
    public partial class FileStorageForm : Form, IStorageFileView
    {
        private readonly FileStoragePresenter _fileStoragePresenter;
        private readonly int _clienteId;

        public DataGridView GridViewLog => this.dataGridViewLog;

        public int ClienteId => _clienteId;

        public FileStorageForm(int clienteId)
        {
            try
            {
                InitializeComponent();

                _fileStoragePresenter = new FileStoragePresenter();

                if (clienteId <= 0) throw new ArgumentException($"Valor do argumento {nameof(clienteId)} não pode ser menor ou igual a zero.");
                _clienteId = clienteId;
            }
            catch (ArgumentException error)
            {
                MessageBox.Show($"Erro ao carregar arquivo. {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StorageFileForm_Load(object sender, EventArgs e)
        {
            try
            {
                _fileStoragePresenter.LoadDataGridViewLog(this, this.Width);
                GridViewLog.ApplyGridViewCellStyle();
            }
            catch (ArgumentException error)
            {
                MessageBox.Show($"Erro ao carregar arquivo. {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ApplicationException error)
            {
                MessageBox.Show($"Erro ao carregar arquivo. {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
