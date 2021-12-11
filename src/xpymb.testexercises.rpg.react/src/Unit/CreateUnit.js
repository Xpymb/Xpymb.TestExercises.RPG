import React, {useEffect, useState} from "react";
import {useNavigate, useParams} from "react-router-dom";
import axios from "axios";
import {apiUrl, config} from "../Data";
import Select from "react-select";

const styles = {
    centerDiv: {
        marginTop: '20px',
        textAlign: 'center',
    },
    inlineDiv: {
        marginTop: '20px',
        textAlign: 'center',
    },
    input: {
        paddingTop: '15px',
        paddingBottom: '15px',
        width: '335px',
        textAlign: 'center',
        borderRadius: '7px',
    },
    inlineInputLeft: {
        paddingTop: '15px',
        paddingBottom: '15px',
        marginRight: '0%',
        textAlign: 'center',
        borderRadius: '7px',
    },
    inlineInputRight: {
        paddingTop: '15px',
        paddingBottom: '15px',
        marginLeft: '3%',
        textAlign: 'center',
        borderRadius: '7px',
    },
    save: {
        background: '#F7CD9C',
        padding: '20px 50px',
        borderRadius: '7px',
        border: 'none',
        boxShadow: '0px 0px 0px 1px rgb(182, 116, 47)',
    },
    reset: {
        background: '#F4C2C2',
        padding: '20px 50px',
        marginLeft: '4%',
        borderRadius: '7px',
        border: 'none',
        boxShadow: '0px 0px 0px 1px rgb(172, 71, 70)',
    },
    selectForm: {
        paddingTop: '15px',
        paddingBottom: '15px',
        width: '335px',
        borderRadius: '7px',
        margin: '0 auto'
    }
}

function CreateUnit() {
    const [ unitId, setUnitId ] = useState('')
    const [ gameClassType, setGameClassType ] = useState(0)
    const navigate = useNavigate()

    function submitHandle() {
        axios.put(apiUrl + '/create', {
                classType: gameClassType,
            },
            config)
            .then(res => {
                navigate('/edit/' + res.data.id)
            })
    }

    function changeHandle(event) {
        setGameClassType(event.value);
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

    return (
        <div>
            <div style={styles.centerDiv}><input style={styles.input} type='text' value={'Unit Id'}  disabled/></div>
            <div style={styles.inlineDiv}>
                <input style={styles.inlineInputLeft} type='text' value={'HP'} disabled/>
                <input style={styles.inlineInputRight} type='text' value={'Max HP'} disabled/>
            </div>
            <div style={styles.inlineDiv}>
                <input style={styles.inlineInputLeft} type='text' value={'Mana'} disabled/>
                <input style={styles.inlineInputRight} type='text' value={'Max Mana'} disabled/>
            </div>
            <div style={styles.centerDiv}><input style={styles.input} type='text' value={'Armor'}  disabled/></div>
            <div style={styles.centerDiv}><input style={styles.input} type='text' value={'Magic Resist'}  disabled/></div>
            <div style={styles.inlineDiv}>
                <input style={styles.inlineInputLeft} type='text' value={'X'} disabled/>
                <input style={styles.inlineInputRight} type='text' value={'Y'} disabled/>
            </div>
            <form style={styles.selectForm} onSubmit={(event) => {
                event.preventDefault();
                submitHandle();
            }}>
                <Select
                    name="form-field-name"
                    value={{value: gameClassType, label: getClassNameByEnum(gameClassType)}}
                    onChange={e => changeHandle(e)}
                    options={[
                        { value: 0, label: getClassNameByEnum(0) },
                        { value: 1, label: getClassNameByEnum(1) },
                        { value: 2, label: getClassNameByEnum(2) },
                    ]}
                />
                <div style={styles.inlineDiv}>
                    <input style={styles.save} type='submit' value='Create'/>
                    <button style={styles.reset} onClick={() => navigate('/list')}>Reset</button>
                </div>
            </form>
        </div>
    )
}

export default CreateUnit