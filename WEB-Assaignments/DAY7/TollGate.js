class vehTypeEntry {
    static count = 0;
    constructor(vehType, vehNum, vehAmt, vehDate) {
        this.count = ++vehTypeEntry.count;
        this.vehType = vehType;
        this.vehNum = vehNum;
        this.vehAmt = vehAmt;
        this.vehDate = vehDate;
    }
}

class tollEdit {
    vehFees = { CAR: "50", TRUCK: "150", BUS: "100", TEMPO: "75" };

    vehDetails = [];

    addDetails = (data1) => this.vehDetails.push(data1);

    getDetails = () => this.vehDetails;
}

const obj = new tollEdit();

// obj.addDetails(new vehTypeEntry("CAR", "KA09-1215", "100", Datemodifier(new Date(2022 / 06 / 05))))


// console.log(obj.vehDetails)
function Datemodifier(time){
    // return `${date.getFullYear()}-${date.getMonth()}-${date.getDate()}`
    const yr = time.getFullYear();
    const month = time.getMonth();
    const date = time.getDate();
    return `${date}-${month}-${yr}`;
    
}


// const vehicle1 = new Map([
//     ["CAR", 100],
//     ["BUS", 200],
//     ["TRUCK", 300],
//     ["TEMPO", 250],
// ])

// function getKey(val) {
//     return [...vehicle1].find(([key, value]) => val === value)[0];
// }

// console.log(getKey(100))