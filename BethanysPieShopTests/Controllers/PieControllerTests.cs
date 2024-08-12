using BethanysPieShop.Controllers;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using BethanysPieShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopTests.Controllers;

public class PieControllerTests
{
    [Fact]
    public void List_EmptyCategory_ReturnsAllPies()
    {
        IPieRepository pieRepository = RepositoryMocks.GetPieRepository().Object;
        ICategoryRepository categoryRepository = RepositoryMocks.GetCategoryRepository().Object;
        PieController pieController = new(pieRepository, categoryRepository);

        var result = pieController.List("");

        var viewResult = Assert.IsType<ViewResult>(result);
        var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
        Assert.Equal(10, pieListViewModel.Pies.Count());
    }
}