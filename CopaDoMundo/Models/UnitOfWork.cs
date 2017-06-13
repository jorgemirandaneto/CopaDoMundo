using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaDoMundo.Models
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed = false;
        private K19Context context = new K19Context();
        private SelecaoRepository selecaoRepository;
        private JogadorRepository jogadorRepository;

        public JogadorRepository JogadorRepository
        {
            get
            {
                if (jogadorRepository == null)
                {
                    jogadorRepository = new JogadorRepository(context);
                }
                return jogadorRepository;
            }
        }

        public SelecaoRepository SelecaoRepository
        {
            get
            {
                if (selecaoRepository == null)
                {
                    selecaoRepository = new SelecaoRepository(context);
                }
                return selecaoRepository;
            }
        }

        public void Salvar()
        {
            context.SaveChanges();
        }

        public virtual void  Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }
    }
}