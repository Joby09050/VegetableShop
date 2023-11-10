import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import Service from "./Components/Service";
import Shopping from "./Components/Shopping";
import Login from "./Components/Login";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route index element={<Login />} />
          <Route path="/" element={<Service />}>
            <Route path="/shopping" element={<Shopping />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
