class Product
{
    constructor(id,name,details,price){
        this.id = id;
        this.name = name;
        this.details = details
        this.price = price
    }
}
class ProductManager
{
    products =[];

    addProducts = (prod) => this.products.push(prod)

    getAllProducts =() => this.products;

    getProducts =(id) =>
    {
        for (const prod of this.products) {
            if(prod.id == id)
            return prod;
        }
        throw `Product by ${id} Id  not found`
    }

    updateProducts = (prod) =>{
        for (const prodRec of this.products) {
            if(prod.id == prodRec.id)
            {
                prodRec.name =prod.name
                prodRec.details = prod.details
                prodRec.price = prod.price
                return;
            }
        }
        throw "Product Not found to update"
    }

}

let instance = new ProductManager()
instance.addProducts(new Product(101,"Laptop","This is Asus laptop",15000))
instance.addProducts(new Product(102,"mobile","This is Lenova",50000))
instance.addProducts(new Product(103,"Tab","This is samsung Tab",15000))
instance.addProducts(new Product(104,"Earbuds","This is one Plus Ear buds",15000))
instance.addProducts(new Product(105,"Washing Machine","This is LG washind Machine",15000))
instance.addProducts(new Product(106,"Fridge","This is WhirlPool Fridge",15000))