import { render } from "react-dom";
import {
    BrowserRouter,
    Routes,
    Route,
    Navigate
} from "react-router-dom";

import App from "./App";
import ListUnits from "./Unit/ListUnits";
import CreateUnit from "./Unit/CreateUnit";
import EditUnit from "./Unit/EditUnit";

const rootElement = document.getElementById("root");
render(
    <BrowserRouter>
        <Routes>
            <Route path="/" element={<Navigate to="/list" />}/>
            <Route path="list" element={<ListUnits />} />
            <Route path="create" element={<CreateUnit />} />
            <Route path="edit/:id" element={<EditUnit />} />
        </Routes>
    </BrowserRouter>,
    rootElement
);