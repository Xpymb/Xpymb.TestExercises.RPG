import axios from "axios";

export const apiUrl = "http://localhost:5068/api/Unit"
export const config = {
    baseURL: process.env.REACT_APP_BASE_URL,
    timeout: 1000 * 20,
    withCredentials: false,
    headers: {
        Accept: "applicaiton/json",
        "Content-Type": "application/json",
    },
};

export function GetListUnits() {
    let listUnits = []
    let num = 0

    return
    console.log(num)

    axios.get(apiUrl + '/list', config)
        .then(res => {
            let listUnitss = res.data;
            console.log(listUnitss);
            return listUnitss;

            num = num + 1;
            console.log(num);
        })

    console.log(listUnits)
    console.log(num)

    //return listUnits
}

export function CreateUnit({ gameClass }) {
    let res = false

    axios.post(apiUrl + '/create', { gameClass })
        .then(res => {
            this.res = res.status === 200;
        })

    return res
}

export function UpdateUnit({ gameClass }) {
    let res = false

    axios.post(apiUrl + '/edit', { gameClass })
        .then(res => {
            this.res = res.status === 200;
        })

    return res
}

export function DeleteUnit({ id }) {
    let res = false

    axios.delete(apiUrl + '/delete?id=' + id)
        .then(res => {
            this.res = res.status === 200;
        })

    return res
}