import Card from "antd/es/card/Card"
import { CardName } from "./Cardname"
import Button from "antd/es/button/button";

interface Props {
    kebabs: Kebab[];
    handleDelete: (id: string) => void;
    handleOpen: (kebab: Kebab) => void;
}

export const Kebabs = ({ kebabs, handleDelete, handleOpen }: Props) => {
    return(
        <div className="cards">
            {kebabs.map((kebab : Kebab) => (
                <Card 
                    key={kebab.id} 
                    title={<CardName name={kebab.name} price={kebab.price}/>} 
                    boardered={false}
                >
                    <p>{kebab.description}</p>
                    <div className="card_buttons">
                        <Button 
                            onClick={() => handleOpen(kebab)}
                            style={{ flex: 1 }}
                        >
                            Edit
                        </Button>
                        <Button
                            onClick={() => handleDelete(kebab.id)}
                            danger
                            style={{ flex: 1 }}
                        >
                            Delete
                        </Button>
                    </div>
                </Card>
            ))}
        </div>
    );
};