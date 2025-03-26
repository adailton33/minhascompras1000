using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views
{
    public partial class EditarProduto : ContentPage
    {
        public EditarProduto()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Obtém o produto que está sendo editado
                Produto produto_anexado = BindingContext as Produto;

                // Cria um novo objeto Produto com os dados atualizados
                Produto p = new Produto
                {
                    Id = produto_anexado.Id,
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToDouble(txt_preco.Text),
                    // Captura a categoria selecionada no Picker
                    Categoria = picker_categoria.SelectedItem as string
                };

                // Atualiza o produto no banco de dados
                await App.Db.Update(p);

                // Exibe uma mensagem de sucesso e retorna à página anterior
                await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                // Em caso de erro, exibe uma mensagem de erro
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}
