import "./globals.css";
import { Layout, Menu } from "antd";
import { Content, Footer, Header } from "antd/es/layout/layout";
import Link from "next/link";

const items = [
  { key: "home", label : <Link href={"/"}>Home</Link> }, 
  { key: "kebabs", label : <Link href={"/kebabs"}>Kebabs</Link> },
];

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <Layout style={{minHeight: "100vh"}}>
          <Header>
            <Menu 
                theme="dark" 
                mode="horizontal" 
                items={items} 
                style={{flex: 1, minWidth: 0}}
            />
          </Header> 
          <Content style={{padding: "0 48px" }}>{children}</Content>
          <Footer style={{textAlign: "center" }}>
            Kebab Store Gen1 2024 by Ilya Shelkunov
          </Footer>
        </Layout>
      </body>
    </html>
  );
}
