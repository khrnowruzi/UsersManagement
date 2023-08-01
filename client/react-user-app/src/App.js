import React from "react";
import { Route, Switch } from "react-router-dom";
import User from "./components/User";

const App = () => {
  return (
    <div className="App">
      <User />
      {/* <Switch>
        <Route path="" Component={() => <User />} />
      </Switch> */}
    </div>
  );
};

export default App;
