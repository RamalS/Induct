import React, { useState, useEffect } from "react";
import "./TableColumn.scss";

type Props = {
  columns: string[];
  header?: boolean;
};

const TableColumn = ({ columns, header }: Props) => {
  return (
    <>
      <div
        className="table-column-container"
        style={{
          display: "grid",
          gridTemplateColumns: `repeat(${columns.length}, 1fr)`,
        }}
      >
        {columns.map((column, index) => (
          <div
            className="table-column"
            key={index}
            style={{ background: header ? "none" : "#000000" }}
          >
            {column}
          </div>
        ))}
      </div>
    </>
  );
};

export default TableColumn;
