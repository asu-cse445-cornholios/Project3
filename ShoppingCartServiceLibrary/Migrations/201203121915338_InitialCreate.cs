namespace ShoppingCartServiceLibrary.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartId);
            
            CreateTable(
                "CartItems",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        ShoppingCartId = c.Int(nullable: false),
                        Item = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("ShoppingCarts", t => t.ShoppingCartId, cascadeDelete: true)
                .Index(t => t.ShoppingCartId);
            
        }
        
        public override void Down()
        {
            DropIndex("CartItems", new[] { "ShoppingCartId" });
            DropForeignKey("CartItems", "ShoppingCartId", "ShoppingCarts");
            DropTable("CartItems");
            DropTable("ShoppingCarts");
        }
    }
}
