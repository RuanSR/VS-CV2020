using CVirtual.Data.Repositories;
using CVirtual.Views.Interfaces;
using System;
using System.Data;
using System.Linq;

namespace CVirtual.Presenter
{
    public class FileStoragePresenter
    {
        public void LoadDataGridViewLog(IStorageFileView view, int contextFormWidth)
        {
            if (contextFormWidth <= 0) throw new ArgumentException($"Valor do argumento {nameof(contextFormWidth)} não pode ser menor ou igual a zero.");
            
            view.GridViewLog.Columns["registro"].Width = contextFormWidth;
            view.GridViewLog.DataSource = new ArquivoRegistrosRepository().GetArquivados(view.ClienteId).Result.OrderByDescending(n => n.ArquivoRegistrosId).ToList();
        }
    }
}
