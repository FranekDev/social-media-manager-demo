'use client';

import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableFooter,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table';
import {
  usePublications,
  formatDateAndTime,
} from '@/lib/hooks/usePublications';
import { Publication } from '@/lib/types/instagram';
import Image from 'next/image';

export default function Page() {
  const publications = usePublications();

  return (
    <main className="w-full flex justify-center items-center">
      <div className="flex justify-center items-center w-[70vw]">
        <Table className="">
          <TableCaption>A list of your scheduled posts.</TableCaption>
          <TableHeader>
            <TableRow>
              <TableHead className="max-w-[300px] text-wrap">Caption</TableHead>
              <TableHead>Image</TableHead>
              <TableHead>Platform</TableHead>
              <TableHead className="text-right">Publication date</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {publications.map((publication) => (
              <TableRow key={publication.publishDate}>
                <TableCell className="font-medium">
                  {publication.caption}
                </TableCell>
                <TableCell>
                  <Image
                    src={publication.imageUrl}
                    className="rounded"
                    alt="Scheduled photo"
                    width={60}
                    height={100}
                  />
                </TableCell>
                <TableCell>{publication.platform ?? 'Instagram'}</TableCell>
                <TableCell className="text-right">
                  {formatDateAndTime(
                    publication.publishDate,
                    publication.publishTime
                  )}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
          <TableFooter>
            <TableRow>
              <TableCell colSpan={3}>Scheduled posts</TableCell>
              <TableCell className="text-right">
                {publications.length}
              </TableCell>
            </TableRow>
          </TableFooter>
        </Table>
      </div>
    </main>
  );
}
