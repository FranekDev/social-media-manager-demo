'use client';

import Link from 'next/link';
import { Button } from './ui/button';
import { usePathname } from 'next/navigation';
import { cn } from '@/lib/utils';
import { useSession } from 'next-auth/react';

export default function NavBar() {
  const pathname = usePathname();
  const { data: session } = useSession();

  const links = [
    {
      name: 'Instagram',
      href: '/platforms/instagram',
      detailHref: '/platforms/instagram/publication',
    },
  ];

  return (
    <>
      <div className="flex flex-col gap-3 p-2">
        <h6 className="text-zinc-400">Platforms</h6>
        {session &&
          links.map((link) => (
            <div
              key={link.href}
              className="flex flex-col justify-start"
            >
              <Button
                key={link.href}
                variant="ghost"
                className={cn({
                  'bg-slate-800 text-slate-200': pathname === link.href,
                })}
              >
                <Link href={link.href}>{link.name}</Link>
              </Button>

              <Button
                key={link.detailHref}
                variant="link"
                className={cn('ml-2', {
                  'underline': pathname === link.detailHref,
                })}
              >
                <Link
                  href={link.detailHref}
                  className="text-xs"
                >
                  Publications
                </Link>
              </Button>
            </div>
          ))}
      </div>
    </>
  );
}
