import React, { useState, useEffect } from "react";

import "./Layout.scss"

type Props = {
  children: React.ReactNode;
};

export const Layout = ({ children }: Props) => {
  return (
    <>
      <div className="layout">{children}</div>
    </>
  );
};
