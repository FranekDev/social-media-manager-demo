import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";

export default function Login() {
    return (
        <main className="flex flex-col items-center justify-center gap-5 h-screen">
            <div className="flex flex-col gap-2">
                <Input type="text" placeholder="Login" />
                <Input type="password" placeholder="Password" />
                <Button>Log In with Instagram</Button>
            </div>
        </main>
    );
}