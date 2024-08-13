using BethanysPieShop.TagHelpers;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;

namespace BethanysPieShopTests.TagHelpers;

public class EmailTagHelperTests
{
    [Fact]
    public void Generates_Email_Link()
    {
        EmailTagHelper emailTagHelper = new()
        {
            Address = "test@bethanyspieshop.com",
            Content = "Email"
        };

        TagHelperContext tagHelperContext =
            new(new TagHelperAttributeList(), new Dictionary<object, object>(), string.Empty);

        TagHelperContent tagHelperContent = new Mock<TagHelperContent>().Object;

        TagHelperOutput tagHelperOutput = new("a", new TagHelperAttributeList(),
            (_, _) => Task.FromResult(tagHelperContent));
        
        emailTagHelper.Process(tagHelperContext, tagHelperOutput);
        
        Assert.Equal("Email", tagHelperOutput.Content.GetContent());
        Assert.Equal("a", tagHelperOutput.TagName);
        Assert.Equal("mailto:test@bethanyspieshop.com", tagHelperOutput.Attributes[0].Value);
    }
}