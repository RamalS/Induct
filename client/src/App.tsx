import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.scss";

const GeneratedVectors = React.lazy(() => import("./pages/GeneratedVectors"));
const Main = React.lazy(() => import("./pages/Main"));


function App() {
  return (
    <div className="app">
      <Router>
        <Routes>
          <Route path="/" element={<Main />} />
          <Route path="/generated-vectors" element={<GeneratedVectors />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
