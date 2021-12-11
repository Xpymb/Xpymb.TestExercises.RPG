import React, {Component, useEffect, useState} from "react";
import { useNavigate } from "react-router-dom";
import {apiUrl, config, GetListUnits} from "../Data";
import axios from "axios";

const styles = {
    table: {
        width: '100%',
        padding: '30px',
        borderCollapse: 'separate',
        borderSpacing: '0 15px',
    },
    row: {
        textAlign: 'center',
        boxShadow: '0px 0px 0px 1.5px rgb(0, 0, 0)',
        borderRadius: '7px',
    },
    percentsTd: {
        width: '5%',
    },
    id: {
        width: '30%',
    },
    hp: {
        padding: '7px',
        borderRadius: '7px',
        background: '#F5C1C1',
        boxShadow: '0px 0px 0px 1px rgb(191, 109, 108)',
    },
    mana: {
        padding: '7px',
        borderRadius: '7px',
        background: '#D1E2FB',
        boxShadow: '0px 0px 0px 1px rgb(106, 135, 184)',
    },
    gameClass: {
        padding: '7px',
        borderRadius: '7px',
        background: '#D9CBE1',
        boxShadow: '0px 0px 0px 1px rgb(159, 126, 173)',
    },
    buttonTd: {
        width: '15%',
    },
    edit: {
        background: '#F7CD9C',
        padding: '16px 20px',
        borderRadius: '7px',
        border: 'none',
        boxShadow: '0px 0px 0px 1px rgb(182, 116, 47)',
    },
    remove: {
        background: '#F4C2C2',
        padding: '16px 20px',
        marginLeft: '10px',
        borderRadius: '7px',
        border: 'none',
        boxShadow: '0px 0px 0px 1px rgb(172, 71, 70)',
    },
    emptyTd: {
        width: '30%',
    },
    add: {
        background: '#CDE3CB',
        width: '100%',
        paddingTop: '20px',
        paddingBottom: '20px',
        textAlign: 'center',
        border: 'none',
        boxShadow: '0px 0px 0px 1px rgb(126, 176, 102)',
        borderRadius: '7px',
    }
}

export default function ListUnits() {
    const [listUnits, setListUnits] = useState([])
    const navigate = useNavigate();

    function getList() {
        axios.get(apiUrl + '/list', config)
            .then(res => {
                setListUnits(res.data);
            })
    }

    function getClassNameByEnum(gameClassType) {
        if (gameClassType === 0) {
            return 'Warrior';
        }
        else if (gameClassType === 1) {
            return 'Ranger';
        }
        else if (gameClassType === 2) {
            return 'Mage';
        }
        else {
            return 'Unexpected';
        }
    }

    function deleteHandler(id) {
        axios.delete(apiUrl + '/remove?id=' + id, config)
            .then(res => {
                getList()
            })
    }

    useEffect(() => getList(), []);

    return (
        <div>
            <button style={styles.add} onClick={() => navigate("/create")}>Add new unit</button>
            <table style={styles.table}>
                {
                    listUnits.map(unit =>
                        <tr style={styles.row}>
                            <td style={styles.id}>UnitId: {unit.id}</td>
                            <td style={styles.percentsTd}><div style={styles.hp}>{unit.hp}%</div></td>
                            <td style={styles.percentsTd}><div style={styles.mana}>{unit.mana}%</div></td>
                            <td style={styles.percentsTd}><div style={styles.gameClass}>{getClassNameByEnum(unit.gameClass.classType)}</div></td>
                            <td style={styles.emptyTd}></td>
                            <td style={styles.buttonTd}>
                                <button style={styles.edit} onClick={(event) => navigate("/edit" + '/' + unit.id)}>EDIT</button>
                                <button style={styles.remove} onClick={() => deleteHandler(unit.id)}>REMOVE</button>
                            </td>
                        </tr>)
                }
            </table>
        </div>
    )
}