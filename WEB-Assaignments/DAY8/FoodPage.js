class Fooddef {
    static no = 0;
    constructor(type, hotel, sprice, quantity, totamt) {
        this.id = ++Fooddef.no;
        this.type = type;
        this.hotel = hotel;
        this.sprice = sprice;
        this.quantity = quantity;
        this.totamt = totamt;
    }
}

class repoFood {
    foodArray = [];

    addfood = (data) => this.foodArray.push(data);

    getfood = () => this.foodArray;
}

const obj = new repoFood();

// obj.addfood(new Fooddef("biriyani","mayura",4,400))

// const hahah = obj.getfood();

// console.log(hahah)?