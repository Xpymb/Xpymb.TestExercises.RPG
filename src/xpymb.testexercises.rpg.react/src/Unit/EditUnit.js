import React, {useEffect, useLayoutEffect, useState} from "react";
import {useNavigate, useParams} from "react-router-dom";
import axios from "axios";
import {apiUrl, config} from "../Data";
import Select from 'react-select';

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

const selectStyles = {
    option: (provided, state) => ({
        ...provided,
        borderBottom: '1px dotted pink',
        color: state.isSelected ? 'red' : 'blue',
        padding: 20,
    }),
    control: () => ({
        // none of react-select's styles are passed to <Control />
        width: 200,
    }),
    singleValue: (provided, state) => {
        const opacity = state.isDisabled ? 0.5 : 1;
        const transition = 'opacity 300ms';

        return { ...provided, opacity, transition };
    }
}

function EditUnit() {
    const [ unit, setUnit ] = useState('')
    const [ gameClassType, setGameClassType ] = useState('')
    const params = useParams()
    const navigate = useNavigate()

    useEffect(() => getUnit(params.id), [])

    function getUnit(id) {
        axios.get(apiUrl + '/get?id=' + id, config)
            .then(res => {
                setUnit(res.data);
                setGameClassType(res.data.gameClass.classType);
            })
    }

    function submitHandle() {
        axios.post(apiUrl + '/edit', {
            id: unit.id,
            classType: gameClassType,
        },
            config)
            .then(res => {
                navigate('/list');
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
            <div style={styles.centerDiv}><input style={styles.input} type='text' value={'Unit Id: ' + unit.id}  disabled/></div>
            <div style={styles.inlineDiv}>
                <input style={styles.inlineInputLeft} type='text' value={'HP: ' + unit.hp} disabled/>
                <input style={styles.inlineInputRight} type='text' value={'Max HP: ' + unit.maxHp} disabled/>
            </div>
            <div style={styles.inlineDiv}>
                <input style={styles.inlineInputLeft} type='text' value={'Mana: ' + unit.mana} disabled/>
                <input style={styles.inlineInputRight} type='text' value={'Max Mana: ' + unit.maxMana} disabled/>
            </div>
            <div style={styles.centerDiv}><input style={styles.input} type='text' value={'Armor: ' + unit.armor}  disabled/></div>
            <div style={styles.centerDiv}><input style={styles.input} type='text' value={'Magic Resist: ' + unit.magicResist}  disabled/></div>
            <div style={styles.inlineDiv}>
                <input style={styles.inlineInputLeft} type='text' value={'X: ' + unit.x} disabled/>
                <input style={styles.inlineInputRight} type='text' value={'Y: ' + unit.y} disabled/>
            </div>
            <form align='center' style={styles.selectForm} onSubmit={(event) => {
                event.preventDefault();
                submitHandle();
            }}>
                <Select
                    name="form-field-name"
                    style={selectStyles}
                    value={{value: gameClassType, label: getClassNameByEnum(gameClassType)}}
                    onChange={e => changeHandle(e)}
                    options={[
                        { value: 0, label: getClassNameByEnum(0) },
                        { value: 1, label: getClassNameByEnum(1) },
                        { value: 2, label: getClassNameByEnum(2) },
                    ]}
                />
                <div style={styles.inlineDiv}>
                    <input style={styles.save} type='submit' value='Save'/>
                    <button style={styles.reset} onClick={() => navigate('/list')}>Reset</button>
                </div>
            </form>
        </div>
    )
}

export default EditUnit