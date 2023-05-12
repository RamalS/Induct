import React, { useState, useEffect, useMemo } from "react";
import {
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
} from "@material-ui/core";
import { useRecoilState } from "recoil";
import { withTestVectors } from "../../../recoil/TestVector/atom";
import TableColumn from "./TableColumn";

export const TableVector = () => {
  const [testVectors, setTestVectors] = useRecoilState(withTestVectors);

  useEffect(() => {
    console.log(testVectors.testVectors, "testVectors");
  }, [testVectors]);

  return (
    <>
      <div className="table-container">
        <TableColumn columns={testVectors.labels} header />
        {testVectors &&
          testVectors.testVectors.slice(0, 10).map((vector, index) => {
            console.log(vector.selectedInput.map((x) => x.value.toString()));

            return (
              <TableColumn
                columns={[
                  vector.id.toString(),
                  vector.isUsed ? "Yes" : "No",
                  ...vector.selectedInput.map((x) => x.value.toString()),
                ]}
                key={index}
              />
            );
          })}
      </div>
    </>
  );
};
