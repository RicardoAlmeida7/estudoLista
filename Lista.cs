using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Lista <T>
    {
        private T[] _itens; //guarda Conta no array
        private int _posicao; //indica qual posicao sera adicionada posteriormente
        public int Tamanho //retorna tamanho do array com contas atribuidas
        {
            get
            {
                return _posicao;
            }
        }
        public Lista(int capacidadeInicial = 5) //paramento que pode ser sobrescrito
        {
            _itens = new T[capacidadeInicial]; // instancia o array
            _posicao = 0;

        }

        public void Adicionar(T item)//adiciona conta no array
        {
            VerificarPosicao(_posicao + 1);//verifica posicao livre no array
            Console.WriteLine("Adicionando conta {0}", _posicao);
            _itens[_posicao] = item;//armazena conta no array

            _posicao++;//incrementa posicao do array
        }
        public void AdicionarVarios(params T[] item) //metodo para adicionar varias contas
        {
            foreach (T conta in item) // conta variavel local, item parametro tipo array
            {
                Adicionar(conta);
            }
        }

        private void VerificarPosicao(int tamanhoNecessario)
        {
            if (tamanhoNecessario >= _itens.Length)//se o tamanho necessario for satisfatorio da um retorno no metodo
            {
                return;
            }

            int novoTamanho = _itens.Length * 2; // determina tamanho do novo array

            if (novoTamanho < tamanhoNecessario) //se o tamanho do array necessario for maior que o novo tamano
                                                 //atribui novo valor no novo array, atualiza quantidade 
            {
                novoTamanho = tamanhoNecessario;
            }


            T[] novoArray = new T[novoTamanho];// cria novo array

            for (int indice = 0; indice < _itens.Length; indice++)//transfere valores do array antigo para o novo
            {
                novoArray[indice] = _itens[indice];
            }

            _itens = novoArray; //atribui novo array na variavel antiga corrigida
        }
        public void Remover(T item)//remover item do array e formatar
        {
            int indiceItem = -1; // para iniciar a varredura em uma posição menor que zero.
            for (int i = 0; i < _posicao; i++) //percorre a lista
            {
                if (_itens[i].Equals(item)) // compara valor declarado na classe ContaCorrente com o parametro item
                {
                    indiceItem = i; // atribui ele como o primeiro valor a ser sobre escrito
                    break;
                }
            }
            for (int i = indiceItem; i < _posicao - 1; i++) // reposiciona os valores do array
            {
                _itens[i] = _itens[i + 1];
            }
            _posicao--; // volta uma posicao
            //_itens[_posicao] = null; //atribui valor nullo para ultima posicao
        }

        public T GetItemNoIndice(int indice) //pega o item na posicao indice
        {
            if (indice < 0 && indice >= _posicao)//verifica se o indexador ñao vai apontar para uma posicao null
            {
                throw new ArgumentOutOfRangeException();
            }

            return _itens[indice];
        }

        public T this[int indice]//indexador 
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

    }
}

