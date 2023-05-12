import React, { Suspense } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { RecoilRoot } from "recoil";
import "./App.scss";

// const GeneratedVectors = React.lazy(() => import("./pages/GeneratedVectors"));
// const Main = React.lazy(() => import("./pages/Main"));

import GeneratedVectors from "./pages/GeneratedVectors";
import Main from "./pages/Main";

function App() {
  return (
    <div className="app">
      <RecoilRoot>
        <Router>
          <Routes>
            <Route
              path="/"
              element={
                <Suspense>
                  <Main />
                </Suspense>
              }
            />
            <Route
              path="/generated-vectors"
              element={
                <Suspense>
                  <GeneratedVectors />
                </Suspense>
              }
            />
          </Routes>
        </Router>
      </RecoilRoot>
    </div>
  );
}

export default App;
