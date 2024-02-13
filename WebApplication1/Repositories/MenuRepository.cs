using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class MenuRepository
    {
        public Menu ProcuraMenu()
        {
            Menu retorno = new Menu();
            List<Section> sections = new List<Section>();

            Section lancheDoDia = new Section
            {
                Title = "Lanche do dia",
                Data = new List<Product>
            {
                new Product { Id = 1, Title = "X-Burger", Price = 10.99, Description = "Delicioso X-Burger com carne, queijo, alface e tomate.", Ingredients = new List<string> { "Carne", "Queijo", "Alface", "Tomate", "Pão" }, Thumbnail = "https://www.estadao.com.br/resizer/5iqKzth3MAAZsxd-Cp4gGLqkHeE=/720x503/filters:format(jpg):quality(80):focal(4615x2575:4625x2585)/cloudfront-us-east-1.images.arcpublishing.com/estadao/4CIGTEL3BNBO3J6ZJVONKPCBDM.jpg", Cover="https://www.estadao.com.br/resizer/5iqKzth3MAAZsxd-Cp4gGLqkHeE=/720x503/filters:format(jpg):quality(80):focal(4615x2575:4625x2585)/cloudfront-us-east-1.images.arcpublishing.com/estadao/4CIGTEL3BNBO3J6ZJVONKPCBDM.jpg" },
                new Product { Id = 2, Title = "Cachorro-quente", Price = 8.99, Description = "Cachorro-quente com salsicha, molho de tomate e batata palha.", Ingredients = new List<string> { "Salsicha", "Pão de Hot Dog", "Molho de Tomate", "Batata Palha" }, Thumbnail = "https://www.estadao.com.br/resizer/5iqKzth3MAAZsxd-Cp4gGLqkHeE=/720x503/filters:format(jpg):quality(80):focal(4615x2575:4625x2585)/cloudfront-us-east-1.images.arcpublishing.com/estadao/4CIGTEL3BNBO3J6ZJVONKPCBDM.jpg", Cover="https://www.estadao.com.br/resizer/5iqKzth3MAAZsxd-Cp4gGLqkHeE=/720x503/filters:format(jpg):quality(80):focal(4615x2575:4625x2585)/cloudfront-us-east-1.images.arcpublishing.com/estadao/4CIGTEL3BNBO3J6ZJVONKPCBDM.jpg" },
                new Product { Id = 3, Title = "Hambúrguer Vegano", Price = 12.99, Description = "Hambúrguer Vegano com cogumelos, abacate e molho especial.", Ingredients = new List<string> { "Hambúrguer Vegano", "Cogumelos", "Abacate", "Pão Integral", "Molho Especial" }, Thumbnail = "https://www.estadao.com.br/resizer/5iqKzth3MAAZsxd-Cp4gGLqkHeE=/720x503/filters:format(jpg):quality(80):focal(4615x2575:4625x2585)/cloudfront-us-east-1.images.arcpublishing.com/estadao/4CIGTEL3BNBO3J6ZJVONKPCBDM.jpg", Cover = "https://www.estadao.com.br/resizer/5iqKzth3MAAZsxd-Cp4gGLqkHeE=/720x503/filters:format(jpg):quality(80):focal(4615x2575:4625x2585)/cloudfront-us-east-1.images.arcpublishing.com/estadao/4CIGTEL3BNBO3J6ZJVONKPCBDM.jpg" }
            }
            };
            sections.Add(lancheDoDia);

            // Promoções
            Section promocoes = new Section
            {
                Title = "Promoções",
                Data = new List<Product>
            {
                new Product { Id = 4, Title = "Combo Família", Price = 25.99, Description = "Combo com 4 hambúrgueres, 4 refrigerantes e 2 batatas fritas grandes." , Ingredients = new List<string> { "Hambúrguer", "Refrigerante", "Batata Frita" }, Thumbnail = "https://curtebh.com.br/wp-content/uploads/2023/05/prato-feito.webp", Cover="https://curtebh.com.br/wp-content/uploads/2023/05/prato-feito.webp" },
                new Product { Id = 5, Title = "Desconto do Dia", Price = 5.99, Description = "Desconto especial no hambúrguer do dia." , Ingredients = new List<string> { "Hambúrguer do Dia" }, Thumbnail = "https://curtebh.com.br/wp-content/uploads/2023/05/prato-feito.webp", Cover="https://curtebh.com.br/wp-content/uploads/2023/05/prato-feito.webp" },
                new Product { Id = 6, Title = "Happy Hour", Price = 7.99, Description = "Desconto especial em bebidas durante o happy hour.", Ingredients = new List<string> { "Bebidas" }, Thumbnail = "https://curtebh.com.br/wp-content/uploads/2023/05/prato-feito.webp", Cover="https://curtebh.com.br/wp-content/uploads/2023/05/prato-feito.webp" }
            }
            };
            sections.Add(promocoes);

            // Acompanhamentos
            Section acompanhamentos = new Section
            {
                Title = "Acompanhamentos",
                Data = new List<Product>
            {
                new Product { Id = 7, Title = "Batata Frita", Price = 4.99, Description = "Porção de batatas fritas crocantes." , Ingredients = new List<string> { "Batata" }, Thumbnail = "https://www.tendaatacado.com.br/dicas/wp-content/uploads/2022/06/como-fazer-batata-frita-topo.jpg", Cover= "https://www.tendaatacado.com.br/dicas/wp-content/uploads/2022/06/como-fazer-batata-frita-topo.jpg" },
                new Product { Id = 8, Title = "Onion Rings", Price = 3.99, Description = "Porção de anéis de cebola empanados." , Ingredients = new List<string> { "Cebola", "Farinha de Rosca" }, Thumbnail = "https://www.tendaatacado.com.br/dicas/wp-content/uploads/2022/06/como-fazer-batata-frita-topo.jpg", Cover= "https://www.tendaatacado.com.br/dicas/wp-content/uploads/2022/06/como-fazer-batata-frita-topo.jpg" },
                new Product { Id = 9, Title = "Nuggets de Frango", Price = 6.99, Description = "Porção de nuggets de frango crocantes." , Ingredients = new List<string> { "Frango", "Farinha de Rosca" }, Thumbnail = "https://www.tendaatacado.com.br/dicas/wp-content/uploads/2022/06/como-fazer-batata-frita-topo.jpg", Cover= "https://www.tendaatacado.com.br/dicas/wp-content/uploads/2022/06/como-fazer-batata-frita-topo.jpg" }
            }
            };
            sections.Add(acompanhamentos);

            // Sobremesas
            Section sobremesas = new Section
            {
                Title = "Sobremesas",
                Data = new List<Product>
            {
                new Product { Id = 10, Title = "Sundae", Price = 3.49, Description = "Sundae de baunilha com calda de chocolate e chantilly." , Ingredients = new List<string> { "Sorvete de Baunilha", "Calda de Chocolate", "Chantilly" }, Thumbnail="https://cache-mcd-ecommerce.appmcdonalds.com/images/BR/63475%20DLV.png", Cover="https://cache-mcd-ecommerce.appmcdonalds.com/images/BR/63475%20DLV.png" },
                new Product { Id = 11, Title = "Torta de Maçã", Price = 4.99, Description = "Fatia de torta de maçã com cobertura crocante." , Ingredients = new List<string> { "Maçã", "Massa de Torta", "Açúcar" }, Thumbnail="https://cache-mcd-ecommerce.appmcdonalds.com/images/BR/63475%20DLV.png", Cover= "https://cache-mcd-ecommerce.appmcdonalds.com/images/BR/63475%20DLV.png" },
                new Product { Id = 12, Title = "Brownie", Price = 2.99, Description = "Brownie de chocolate com nozes e sorvete de creme." , Ingredients = new List<string> { "Chocolate", "Nozes", "Sorvete de Creme" },Thumbnail = "https://cache-mcd-ecommerce.appmcdonalds.com/images/BR/63475%20DLV.png", Cover = "https://cache-mcd-ecommerce.appmcdonalds.com/images/BR/63475%20DLV.png" }
            }
            };
            sections.Add(sobremesas);

            // Bebidas
            Section bebidas = new Section
            {
                Title = "Bebidas",
                Data = new List<Product>
            {
                new Product { Id = 13, Title = "Refrigerante", Price = 2.49, Description = "Lata de refrigerante de cola gelada." , Ingredients = new List<string> { "Refrigerante", "Gelo" }, Thumbnail = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQYggJdH5sYPORZO-Vwu5KL4l4D_8rCbLmu5Q&usqp=CAU", Cover="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQYggJdH5sYPORZO-Vwu5KL4l4D_8rCbLmu5Q&usqp=CAU" },
                new Product { Id = 14, Title = "Suco Natural", Price = 3.49, Description = "Copo de suco natural de laranja." , Ingredients = new List<string> { "Laranja" }, Thumbnail = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQYggJdH5sYPORZO-Vwu5KL4l4D_8rCbLmu5Q&usqp=CAU", Cover="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQYggJdH5sYPORZO-Vwu5KL4l4D_8rCbLmu5Q&usqp=CAU" },
                new Product { Id = 15, Title = "Água Mineral", Price = 1.99, Description = "Garrafa de água mineral sem gás." , Ingredients = new List<string> { "Água" }, Thumbnail = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQYggJdH5sYPORZO-Vwu5KL4l4D_8rCbLmu5Q&usqp=CAU", Cover="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQYggJdH5sYPORZO-Vwu5KL4l4D_8rCbLmu5Q&usqp=CAU" }
            }
            };
            sections.Add(bebidas);

            retorno.Sections = sections;

            return retorno;
        }
    }
}
